using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class ListOfGalleries : MonoBehaviour {
    public int galleriesCount;
    public int[] galleriesIndexes;
    public List<Gallery> gallaries = new List<Gallery>();
    public GameObject portraitCanvas=GameObject.FindWithTag("portraitCanvas");
    public GameObject landscapeCanvas;
   

    // Use this for initialization
    void Awake () {
       
      
    }
	public void Renew()
    {
        Debug.Log("list renew");
        galleriesCount = 0;
        foreach (var obj in GameObject.FindGameObjectsWithTag("gallery"))
        {
            galleriesCount++;
            gallaries.Add(obj.GetComponent<Gallery>());
            
        }
        for (int i = 0; i < galleriesCount; i++)
        {
            Transform galleryButton = portraitCanvas.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(i);
            galleryButton.GetChild(0).GetChild(0).GetComponent<Text>().text = gallaries[i].galleryName;
            galleryButton.GetComponent<Image>().sprite = gallaries[i].galleryAvatar;
        }
        Debug.Log("end renew");
    }


}
