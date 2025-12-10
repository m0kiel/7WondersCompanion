using System;
using UnityEngine;

public class AuthenticationEvents : MonoBehaviour
{
    public static event EventHandler<LogInSuccessfulEventArgs> LogInSuccessful;

    public class LogInSuccessfulEventArgs : EventArgs { public UIScreen screen; }

    public static void InvokeChangeCurrentScreen(GameObject sender, UIScreen newScreen)
    {
        LogInSuccessful?.Invoke(sender, new LogInSuccessfulEventArgs { screen = newScreen });
    }
}
