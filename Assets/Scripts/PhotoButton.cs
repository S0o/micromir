using UnityEngine;
using System.Collections;

public class PhotoButton : MonoBehaviour {

   
    public Photo photo;
    public Transform textTransf;

    public void PhotoButtonClick()
    {
        UIcontroller UIscript = GameObject.FindGameObjectWithTag("UIcontroller").GetComponent<UIcontroller>();
        UIscript.OpenViewer(photo);
    }
   
}
