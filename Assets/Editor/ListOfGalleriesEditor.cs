using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(ListOfGalleries))]
[CanEditMultipleObjects]

public class ListOfGalleriesEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Renew"))
        {
        
        ListOfGalleries listScript = (ListOfGalleries)target;
        listScript.Renew();
        }
    }
}
