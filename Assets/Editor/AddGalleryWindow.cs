using UnityEngine;
using UnityEditor;
using System.Collections;

public class AddGalleryWindow : EditorWindow
{
    // [MenuItem("Window/AddPhoto")]

    string galleryName = "Gallery Name";
    Sprite avatar;
    float price;
    public ListOfGalleries list;

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(AddGalleryWindow));
    }


    void OnGUI()
    {

        
        GUILayout.Label("Add new Gallery");
        galleryName = EditorGUILayout.TextField("Name", galleryName);
        avatar = (Sprite)EditorGUILayout.ObjectField("Avatar", avatar, typeof(Sprite), false); ;
        price = EditorGUILayout.FloatField("Price", price);

        if (GUILayout.Button("Add gallery"))
        {
            list.AddNewGallery(galleryName, avatar, price);
            this.Close();
        }
    }
}

