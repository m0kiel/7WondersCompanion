using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UIScreen))]
public class RevealScreenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        UIScreen thisScreen = (UIScreen)target;

        if (GUILayout.Button("Toggle Visibility"))
        {
            thisScreen.ToggleScreenVisibilityEditor();
        }
        if (GUILayout.Button("Show This Screen"))
        {
            GameObject mainMenu = GameObject.FindGameObjectWithTag("Screens").gameObject;

            for (int i = 1; i < mainMenu.transform.childCount; i++)
            {
                mainMenu.transform.GetChild(i).GetComponent<UIScreen>().HideScreenVisibilityEditor();
            }

            thisScreen.DisplayScreenVisibilityEditor();
        }
    }
}
