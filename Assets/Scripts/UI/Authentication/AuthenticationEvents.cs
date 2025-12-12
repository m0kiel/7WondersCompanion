using System;
using UnityEngine;

public class AuthenticationEvents : MonoBehaviour
{
    public static event EventHandler<LogInSuccessfulEventArgs> LogInSuccessful;

    public class LogInSuccessfulEventArgs : EventArgs { }

    public static void InvokeChangeCurrentScreen(GameObject sender)
    {
        LogInSuccessful?.Invoke(sender, new LogInSuccessfulEventArgs {});
    }
}
