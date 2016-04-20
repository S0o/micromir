using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Photo))]
[CanEditMultipleObjects]

public class PhotoEditor : Editor
{
    SerializedProperty photoId;
    SerializedProperty photoName;
    SerializedProperty label1;
    SerializedProperty label2;
    SerializedProperty photoAvatar;
    SerializedProperty image;

    void OnEnable()
    {
        photoName = serializedObject.FindProperty("photoName");
        photoId = serializedObject.FindProperty("id");
        photoAvatar = serializedObject.FindProperty("avatar");
        image = serializedObject.FindProperty("image");
        label1 = serializedObject.FindProperty("label1");
        label2 = serializedObject.FindProperty("label2");

    }


    public override void OnInspectorGUI()
    {
       // DrawDefaultInspector();
        serializedObject.Update();

        EditorGUILayout.PropertyField(photoName);
        EditorGUILayout.PropertyField(photoId);
        EditorGUILayout.PropertyField(photoAvatar);
        EditorGUILayout.PropertyField(label1);
        EditorGUILayout.PropertyField(label2);
        EditorGUILayout.PropertyField(image);
        serializedObject.ApplyModifiedProperties();



        Photo photoScript = (Photo)target;
    


        if (GUILayout.Button("Renew"))
        {
            photoScript.Renew();

        }
    

        if (GUILayout.Button("Delete photo"))
        {
            photoScript.DeletePhoto();
        }


    }
}
