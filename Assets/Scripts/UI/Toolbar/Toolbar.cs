using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toolbar : MonoBehaviour
{
    [SerializeField] private UIScreen currentScreen;
    void Start()
    {
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        UtilitiesUI.GetComponentByName<Button>(gameObject, "ProfileButton").onClick.AddListener(() =>
        {
            UtilitiesUI.GetComponentByName<UIScreen>(transform.parent.gameObject, "ProfileScreen").ChangeScreens(Screens.Profile, currentScreen);
        });

        UtilitiesUI.GetComponentByName<Button>(gameObject, "MyGamesButton").onClick.AddListener(() =>
        {
            UtilitiesUI.GetComponentByName<UIScreen>(transform.parent.gameObject, "MyGamesScreen").ChangeScreens(Screens.MyGames, currentScreen);
        });
    }

    public void SetCurrentScreen(UIScreen newScreen)
    {
        currentScreen = newScreen;
    }
}
