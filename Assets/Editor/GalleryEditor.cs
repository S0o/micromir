using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Gallery))]
[CanEditMultipleObjects]

public class GalleryEditor : Editor
{

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
        photosCount = serializedObject.FindProperty("photosCount");

    }

   
    public override void OnInspectorGUI()
    {
     // DrawDefaultInspector();
        serializedObject.Update();

        EditorGUILayout.PropertyField(galleryName);
        EditorGUILayout.PropertyField(galleyIndex);
        EditorGUILayout.PropertyField(galleryAvatar);
        EditorGUILayout.PropertyField(price);

        serializedObject.ApplyModifiedProperties();



        EditorGUILayout.PropertyField(photosCount);
        

        Gallery galleryScript = (Gallery)target;
        // galleryScript.Renew();
        /*   if (GUILayout.Button("Renew"))
           {

              galleryScript.Renew();
           }*/


        if (GUILayout.Button("Renew"))
        {
            galleryScript.Renew();

            serializedObject.ApplyModifiedProperties();

        }
        if (GUILayout.Button("Add Photo"))
        {

            AddPhotoWindow win= AddPhotoWindow.GetWindow<AddPhotoWindow>();
             win.galleryName= serializedObject.FindProperty("galleryName").stringValue;
            win.gallery = galleryScript;
        }

        if (GUILayout.Button("Delete gallery"))
        {
            galleryScript.DeleteGallery();
        }
        

    }
}

