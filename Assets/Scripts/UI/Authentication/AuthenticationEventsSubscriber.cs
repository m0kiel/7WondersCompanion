using UnityEngine;

public class AuthenticationEventsSubscriber : EventsSubscriber
{
    private void Events_LogInSuccessful(object sender, AuthenticationEvents.LogInSuccessfulEventArgs e)
    {
        // Change to MyGamesScreen
        UIScreen signInScreen = GameObject.FindGameObjectWithTag("Screens").transform.Find("SignIn").GetComponent<UIScreen>();
        GameObject.FindGameObjectWithTag("Screens").transform.Find("MyGamesScreen").GetComponent<UIScreen>().ChangeScreens(signInScreen);
    }

    protected override void SubscribeToEvents()
    {
        AuthenticationEvents.LogInSuccessful += Events_LogInSuccessful;
    }

    protected override void UnsubscribeToEvents()
    {
        AuthenticationEvents.LogInSuccessful -= Events_LogInSuccessful;
    }
}
