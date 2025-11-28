using System;
using System.Collections.Generic;
using UnityEngine;

public enum Screens { None, Profile, MyGames, AddGame, Register, Login}
public class UIScreen : MonoBehaviour
{
    private List<GameObject> elements = new();
    private Dictionary<Screens, UIScreen> screenConections = new();

    [SerializeField] private Screens screenKey;
    [SerializeField] private List<UIScreen> screens;
    
    void Start()
    {
        if (screenKey == Screens.None) { Debug.LogError("UIScreen: " + gameObject.name + " has None as screenKey"); return; }

        GetAllElements();
        SetScreenConnections();
    }
    private void GetAllElements()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            elements.Add(transform.GetChild(i).gameObject);
        }
    }
    private void SetScreenConnections()
    {
        for (int i = 0; i < screens.Count; i++)
        {
            screenConections.Add(screens[i].screenKey, screens[i]);
            Debug.Log(screens[i].screenKey);
        }

        screens.Clear();
    }

    public void ChangeScreens(Screens screenKey)
    {
        //Debug.Log("Code is in: " + gameObject.name);
        //Debug.Log("Change to: " + screenKey);
        //foreach (Screens screen in screenConections.Keys)
        //{
        //    Debug.Log("Dict has : " + screen.ToString());
        //}

        if (!screenConections.ContainsKey(screenKey)) { Debug.LogError("ScreenKey not in ScreenConnections"); return; }

        screenConections[screenKey].DisplayScreen();
        HideScreen();
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
        //GetComponent<BaseScreen>().OnGameObjectEnabled();
        
    }
    public void HideScreen()
    {
        //GetComponent<BaseScreen>().OnGameObjectDisabled();
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
