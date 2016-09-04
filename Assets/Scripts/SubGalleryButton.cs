using UnityEngine;
using System.Collections;

public class SubGalleryButton : MonoBehaviour {

    public Transform subGalleryPanel;
    public Transform textTransf;

    public void SubGalleryButtonClick()
    {
        UIcontroller UIscript = GameObject.FindGameObjectWithTag("UIcontroller").GetComponent<UIcontroller>();
        UIscript.OpenPanel(subGalleryPanel);

    }
}
