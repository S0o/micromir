using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Text;
class MyWindow : EditorWindow
{
   

    
    [MenuItem("Gallery/Scan")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(MyWindow));
    }

    public void DeleteChildren(Transform trans)
    {
       
        while (trans.childCount != 0)
        {
            DestroyImmediate(trans.GetComponentsInChildren<Transform>(true)[1].gameObject);
        }
    }
    public void deleteAll()
         
    {
       UIcontroller UIscript = GameObject.FindGameObjectWithTag("UIcontroller").GetComponent<UIcontroller>();
       UIscript.languageManager.listOfGallaries.Clear();
       UIscript.languageManager.listOfSubGallaries.Clear();
        UIscript.languageManager.listOfPhoto.Clear();
        DeleteChildren(UIscript.portraitListContent);
       DeleteChildren(UIscript.gallariesTransform);
       DeleteChildren(UIscript.subGallariesTransform);
     
    }

    void OnGUI()
    {
        UIcontroller UIscript = GameObject.FindGameObjectWithTag("UIcontroller").GetComponent<UIcontroller>();
        if (GUILayout.Button("Scan Gallery"))
        {
            
            deleteAll();
            
            if (Directory.Exists("Gallery"))
            {
                UIscript.languageManager.languages.Clear();//Для адекватной прездагрузки языка  
                string dictionary = File.ReadAllText("Gallery/Settings.xml");
                UIscript.languageManager.GlobalReader(dictionary);

              
                foreach (string dirName in Directory.GetDirectories("Gallery"))
                {
                    UIscript.GenerateGallery(dirName);  
                    
                    
                }
            }

            // this.Close();
            UIscript.languageManager.ChangeLanguage();
           
        }
 
            if (GUILayout.Button("delete Gallery"))
        {
            deleteAll();
           // this.Close();
        }
    }
}