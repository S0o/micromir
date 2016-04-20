using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

public class GalleryButton : MonoBehaviour {
    public Text text;
    public string name;
    public Gallery gallery;
    public Photo photo;
    public GameObject portraitCanvas;
    public Transform portraitGalleryPanel;
    public GameObject photoViewer;
    public void CloseGalleryPanels()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("portGallaries"))
        {
            obj.SetActive(false);
        }
    }


    public void OnClick()
    {
        CloseGalleryPanels();
        UIManager.OpenPanel(gallery.portraitPanel.transform);
        UIManager.OpenPanel(portraitCanvas.transform.GetChild(1));
        text.text = name;
        gallery.listOfGallaries.managerUI.currentGalleryPortraitPanel = gallery.portraitPanel.transform;
        UIManager.ClosePanel(portraitCanvas.transform.GetChild(0));
    }
}
