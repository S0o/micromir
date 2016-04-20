﻿using UnityEngine;
using UnityEditor;
using System.Collections;

public class AddPhotoWindow : EditorWindow
{
    // [MenuItem("Window/AddPhoto")]

    string gallaryName = "Gallery Name";
    Sprite avatar;
    Sprite image;
    public Gallery gallery;
    public string galleryName;
    public string photoName="Photo Name";
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(AddPhotoWindow));
    }

    void OnGUI()
    {
        GUILayout.Label("Add new photo to "+galleryName+" gallery ", EditorStyles.boldLabel);
        photoName = EditorGUILayout.TextField("Name", photoName);
        avatar = (Sprite)EditorGUILayout.ObjectField("Avatar", avatar, typeof(Sprite), false); 
        image= (Sprite)EditorGUILayout.ObjectField("Photo", image, typeof(Sprite), false);

        if (GUILayout.Button("Add Photo"))
        {
            gallery.AddNewPhoto(photoName, avatar,image);
            this.Close();
        }
    }
}
