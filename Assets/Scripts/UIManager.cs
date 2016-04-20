using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public static class UIManager {

    public static void ClosePanel(Transform Panel)
    {
        Panel.gameObject.SetActive(false);
    }
    public static void ChangeText(Transform textTrans,string text)
    {
        textTrans.GetComponent<Text>().text = text;
    }
    public static void OpenPanel(Transform Panel)
    {
        Panel.gameObject.SetActive(true);
    }
}
