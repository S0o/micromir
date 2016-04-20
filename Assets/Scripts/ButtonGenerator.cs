using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor.Events;
#endif 
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonGenerator : MonoBehaviour {
    public Text text;
    public string name;
    public Gallery gallery;
    public Photo photo;
    public GameObject portraitCanvas;
    public Transform portraitGalleryPanel;
    public GameObject photoViewer;
    // Use this for initialization

    public void GenerateGallery () {
#if UNITY_EDITOR
        Button btn =transform.GetComponent<Button>();
        UnityEvent onClick = btn.onClick;

       UnityEventTools.RegisterPersistentListener(onClick, 0, () => CloseGalleryPanels());
        UnityEventTools.RegisterPersistentListener(onClick, 1,delegate { UIManager.OpenPanel(gallery.portraitPanel.transform); });
        UnityEventTools.RegisterPersistentListener(onClick, 2, delegate { UIManager.OpenPanel(portraitCanvas.transform.GetChild(1)); });
        UnityEventTools.RegisterPersistentListener(onClick, 3, () => ChangeText());
        UnityEventTools.RegisterPersistentListener(onClick, 4, delegate { UIManager.ClosePanel(portraitCanvas.transform.GetChild(0)); });
#endif
    }
    public void GeneratePhoto()
    {

#if UNITY_EDITOR
        Button btn = transform.GetComponent<Button>();
        UnityEvent onClick = btn.onClick;

        UnityEventTools.RegisterPersistentListener(onClick, 0, () => CloseGalleryPanels());
        UnityEventTools.RegisterPersistentListener(onClick, 1, delegate { UIManager.ClosePanel(portraitCanvas.transform.GetChild(1)); });
        UnityEventTools.RegisterPersistentListener(onClick, 2, delegate { UIManager.ClosePanel(portraitCanvas.transform.GetChild(0)); });
        UnityEventTools.RegisterPersistentListener(onClick, 3, () => ViewerUpdate());
        UnityEventTools.RegisterPersistentListener(onClick, 4, delegate { UIManager.OpenPanel(portraitCanvas.transform.GetChild(2)); });
#endif
    }

    public void ViewerUpdate()
    {
        
        photoViewer.transform.GetChild(1).GetChild(0).GetComponent<Text>().text=name;
        photoViewer.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().sprite = photo.image;

    }
    public  void ChangeText()
    {
       text.text = name;
        gallery.listOfGallaries.managerUI.currentGalleryPortraitPanel = gallery.portraitPanel.transform;
    }
    public void CloseGalleryPanels()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("portGallaries"))
        {
            obj.SetActive(false);
        }
    }


}
