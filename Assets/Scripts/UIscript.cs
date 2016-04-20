using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIscript : MonoBehaviour {
    public string currentGalleryName;
    public string currentPhotoName;
    public Gallery currentGallery;
    public Transform currentGalleryPortraitPanel;
    public Transform portraitCanvas;
    public void ClosePanel(Transform Panel)
    {
        Panel.gameObject.SetActive(false);
    }
    public void OpenPanel(Transform Panel)
    {
        Panel.gameObject.SetActive(true);
    }
    public void ChangeText(Transform textTrans, string text)
    {
        textTrans.GetComponent<Text>().text = text;
    }
    public void ReturnToCurrent()
    {
        CloseAllGallaryPanels();
        OpenPanel(currentGalleryPortraitPanel);
        OpenPanel(portraitCanvas.GetChild(1));
       
       
    }
    public void CloseAllGallaryPanels()
    {
        
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("portGallaries"))
            {
                obj.SetActive(false);
            }
        
    }

}
