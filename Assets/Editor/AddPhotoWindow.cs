using UnityEngine;
using UnityEditor;
using System.Collections;

public class AddPhotoWindow : EditorWindow
{
    // [MenuItem("Window/AddPhoto")]

    public string galleryName;
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(AddPhotoWindow));
    }

    void OnGUI()
    {
        GUILayout.Label("Add new photo to "+galleryName+" gallery ", EditorStyles.boldLabel);

    }
}
