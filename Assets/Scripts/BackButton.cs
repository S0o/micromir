using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {
    
    
    public void BackButtonClick()
    {
        UIcontroller UIscript = GameObject.FindGameObjectWithTag("UIcontroller").GetComponent<UIcontroller>();
        UIscript.ClosePanel(this.transform);
        UIscript.OpenPanel(UIscript.portraitList);
    }
}
