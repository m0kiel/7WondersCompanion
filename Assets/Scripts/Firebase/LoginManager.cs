using UnityEngine;
using Unity.Services.Authentication;
using System.Threading.Tasks;
using Unity.Services.Core;
using UnityEngine.UI;
using System;

#if UNITY_ANDROID
using GooglePlayGames;
using GooglePlayGames.BasicApi;
#endif

public class LoginManager : MonoBehaviour
{
    private string googePlayGamesToken;
    [SerializeField] private Button googlePlayGamesButtonSignIn;

    async void Start()
    {
        #if UNITY_ANDROID
            await InitializeUnityServices();

            PlayGamesPlatform.DebugLogEnabled = true;
            PlayGamesPlatform.Activate();
            LoginGooglePlayGames();
            googlePlayGamesButtonSignIn.onClick.AddListener(() => {
            StartSignInGooglePlayGames();
        });
        #endif
    }


#if UNITY_ANDROID
    public void LoginGooglePlayGames()
    {
        PlayGamesPlatform.Instance.Authenticate((status) =>
        {
            if (status == SignInStatus.Success)
            {
                Debug.Log("Login Google Play Games successful");

                PlayGamesPlatform.Instance.RequestServerSideAccess(true, code =>
                {
                    Debug.Log("Authorization Code: " + code);
                    googePlayGamesToken = code;
                });
            }
            else
            {
                Debug.LogError("Google Play Games login unsuccesful | " + status.ToString());
            }
        });
    }

    public void StartSignInGooglePlayGames()
    {
        if (!PlayGamesPlatform.Instance.IsAuthenticated())
        {
            Logger.Instance.LogInfo("Not Authenticated");
            LoginGooglePlayGames();
            return;
        }
        Logger.Instance.LogInfo("Try SignIn Authenticated");
        SignInGooglePlayGames();
        AuthenticationEvents.InvokeChangeCurrentScreen(gameObject);
    }

    private async void SignInGooglePlayGames()
    {
        if (string.IsNullOrEmpty(googePlayGamesToken))
        {
            Debug.LogError("googlePlayGamesToken is null or empty");
            return;
        }

        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await SignInGooglePlayGamesAsync(googePlayGamesToken);
        }
        else
        {
            await LinkGooglePlayGamesAsync(googePlayGamesToken);
        }
    }

    private async Task SignInGooglePlayGamesAsync(string authCode)
    {
        try
        {
            await AuthenticationService.Instance.SignInWithGooglePlayGamesAsync(authCode);
            Debug.Log("SignInScreen Successful");
            Logger.Instance.LogInfo("SignIn Success");
        }
        catch (AuthenticationException ex)
        {
            Debug.LogException(ex);
            Logger.Instance.LogInfo("Auth Exception");
        }
        catch (RequestFailedException ex)
        {
            Debug.LogException(ex);
            Logger.Instance.LogInfo("Request Exception");
        }
    }

    private async Task LinkGooglePlayGamesAsync(string authCode)
    {
        try
        {
            await AuthenticationService.Instance.LinkWithGooglePlayGamesAsync(authCode);
            Debug.Log("SignInScreen Successful");
        }
        catch (AuthenticationException ex) when (ex.ErrorCode == AuthenticationErrorCodes.AccountAlreadyLinked) 
        {
            Debug.LogError("This user is already linked with another account, login instead");
        }
        catch (AuthenticationException ex)
        {
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            Debug.LogException(ex);
        }
    }

    private async Task InitializeUnityServices()
    {
        try
        {
            await UnityServices.InitializeAsync();
            Debug.Log("UGS initialized!");
        }
        catch (Exception e)
        {
            Debug.LogError($"UGS failed to initialize: {e}");
        }
    }

#endif
}
