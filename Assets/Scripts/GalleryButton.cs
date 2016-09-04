using UnityEngine;
using System.Collections;

public class GalleryButton : MonoBehaviour {

    
    public Transform galleryPanel;
    public Transform textTransf;

    public void GalleryButtonClick()
    {
        UIcontroller UIscript = GameObject.FindGameObjectWithTag("UIcontroller").GetComponent<UIcontroller>();
        UIscript.OpenPanel(galleryPanel);

    }

}
