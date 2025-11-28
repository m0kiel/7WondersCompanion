using System;
using Unity.VisualScripting;
using UnityEngine;

public class ToolbarEvents : MonoBehaviour
{
    public static event EventHandler<ChangeCurrentScreenEventArgs> ChangeCurrentScreen;

    public class ChangeCurrentScreenEventArgs : EventArgs {  public UIScreen screen; }

    public static void InvokeChangeCurrentScreen(GameObject sender, UIScreen newScreen)
    {
        ChangeCurrentScreen?.Invoke(sender, new ChangeCurrentScreenEventArgs { screen = newScreen });
    }
}
