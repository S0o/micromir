using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Gallery))]
[CanEditMultipleObjects]

public class GalleryEditor : Editor {

    SerializedProperty galleyId;
    SerializedProperty galleryName;
    SerializedProperty price;
    SerializedProperty galleyIndex;
    SerializedProperty photosCount;
    SerializedProperty galleryAvatar;
    SerializedProperty photos;
    
    void OnEnable()
    {
        galleryName = serializedObject.FindProperty("galleryName");
        galleyIndex = serializedObject.FindProperty("id");
        galleryAvatar = serializedObject.FindProperty("galleryAvatar");
        price = serializedObject.FindProperty("price");
        photosCount= serializedObject.FindProperty("photosCount");
        
    }

    public override void OnInspectorGUI()
    {
      //  DrawDefaultInspector();
        serializedObject.Update();

        EditorGUILayout.PropertyField(galleryName);
        EditorGUILayout.PropertyField(galleyIndex);
        EditorGUILayout.PropertyField(galleryAvatar);
        EditorGUILayout.PropertyField(price);
        
        serializedObject.ApplyModifiedProperties();

       
        Gallery galleryScript = (Gallery)target;
        galleryScript.GalleryRenew();

     

        if (GUILayout.Button("Add Photo"))
        {  
                AddPhotoWindow.GetWindow<AddPhotoWindow>().galleryName = serializedObject.FindProperty("galleryName").stringValue; ;
        }

        EditorGUILayout.PropertyField(photosCount);

    }
}
