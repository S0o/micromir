using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(ListOfGalleries))]
[CanEditMultipleObjects]

public class ListOfGalleriesEditor : Editor
{
    ListOfGalleries listScript;
   
    public override void OnInspectorGUI()
    {
      // DrawDefaultInspector();
       
        listScript = (ListOfGalleries)target;
        if (GUILayout.Button("Renew"))
        {
            listScript.Renew();
            EditorUtility.SetDirty(target);
        }

        if (GUILayout.Button("Add gallery"))
        {
            AddGalleryWindow.GetWindow<AddGalleryWindow>().list= listScript;
        }

      
    }
}
