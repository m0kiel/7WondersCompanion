using System;
using System.Collections.Generic;
using UnityEngine;

public enum Screens { None, Profile, MyGames, AddGame, Register, Login}
public class UIScreen : MonoBehaviour
{
    private List<GameObject> elements = new();

    [SerializeField] private Screens screenKey;
    
    void Start()
    {
        if (screenKey == Screens.None) { Debug.LogError("UIScreen: " + gameObject.name + " has None as screenKey"); return; }

        GetAllElements();
    }
    private void GetAllElements()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            elements.Add(transform.GetChild(i).gameObject);
        }
    }
    public void ChangeScreens(Screens screenKey, UIScreen uiScreen)
    {
        uiScreen.HideScreen();
        DisplayScreen();
        ToolbarEvents.InvokeChangeCurrentScreen(gameObject, this);
    }

    public void DisplayScreen()
    {
        elements.ForEach(e => 
        {
            e.SetActive(true);
        });
        GetComponent<BaseScreen>().OnGameObjectEnabled();
        
    }
    public void HideScreen()
    {
        GetComponent<BaseScreen>().OnGameObjectDisabled();
        elements.ForEach(e => 
        { 
            e.SetActive(false); 
        });
    }

    public void SetScreenVisibility(bool state)
    {
        elements.ForEach(e =>
        {
            e.SetActive(state);
        });
    }

    // Editor
    public void ToggleScreenVisibilityEditor()
    {
        List<GameObject> childElements = new();

        for (int i = 0; i < transform.childCount; i++)
        {
            childElements.Add(transform.GetChild(i).gameObject);
        }

        childElements.ForEach(e => { e.SetActive(!e.activeSelf); });
    }

    public void DisplayScreenVisibilityEditor()
    {
        List<GameObject> childElements = new();

        for (int i = 0; i < transform.childCount; i++)
        {
            childElements.Add(transform.GetChild(i).gameObject);
        }

        childElements.ForEach(e => { e.SetActive(true); });
    }
    public void HideScreenVisibilityEditor()
    {
        List<GameObject> childElements = new();

        for (int i = 0; i < transform.childCount; i++)
        {
            childElements.Add(transform.GetChild(i).gameObject);
        }

        childElements.ForEach(e => { e.SetActive(false); });
    }
}
