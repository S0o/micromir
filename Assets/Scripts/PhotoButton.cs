using UnityEngine;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

public class PhotoButton : MonoBehaviour {

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
        UIManager.ClosePanel(portraitCanvas.transform.GetChild(1));
        UIManager.ClosePanel(portraitCanvas.transform.GetChild(0));
        photoViewer.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = name;
        photoViewer.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().sprite = photo.image;
        gallery.listOfGallaries.managerUI.currentGalleryPortraitPanel = gallery.portraitPanel.transform;
        UIManager.OpenPanel(portraitCanvas.transform.GetChild(2));
    }
}
