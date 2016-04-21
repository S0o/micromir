using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIscript : MonoBehaviour
{
    public string currentGalleryName;
    public string currentPhotoName;
    public Gallery currentGallery;
    public Transform currentGalleryPortraitPanel;
    public Transform portraitCanvas;
    public Transform viewer;
    public ViewerZoom zoom;

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
        Transform current = currentGalleryPortraitPanel;
        CloseAllGallaryPanels();
        currentGalleryPortraitPanel = current;
        OpenPanel(currentGalleryPortraitPanel);
        OpenPanel(portraitCanvas.GetChild(1));

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentGalleryPortraitPanel == null) Application.Quit();
            else if (viewer.gameObject.activeInHierarchy)
            {
                viewer.gameObject.SetActive(false);
                ReturnToCurrent();
                zoom.Return();
            }
            else
                CloseAllGallaryPanels();
        }

    }
    public void CloseAllGallaryPanels()
    {

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("portGallaries"))
        {
            obj.SetActive(false);
            currentGalleryPortraitPanel = null;
        }

    }
}
