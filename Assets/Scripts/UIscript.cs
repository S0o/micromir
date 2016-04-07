using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIscript : MonoBehaviour {
    public string currentGalleryName;
    public string currentPhotoName;
    public Transform currentGalleryPortraitPanel;

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
}
