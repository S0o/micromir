using UnityEngine;
using System.Collections;

public class UIscript : MonoBehaviour {

    public void ClosePanel(Transform Panel)
    {
        Panel.gameObject.SetActive(false);
    }
    public void OpenPanel(Transform Panel)
    {
        Panel.gameObject.SetActive(true);
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
