using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Events;
using UnityEngine.Events;

public class ListOfGalleries : MonoBehaviour {
    public int galleriesCount;
    public UIscript managerUI;
    public List<Gallery> galleries = new List<Gallery>();
    public List<GameObject> galleryButtons = new List<GameObject>();
    public GameObject portraitCanvas;
    public GameObject landscapeCanvas;
    public GameObject galleryButtonPrefab;
    public GameObject galleryPanelPrefab;
    public string nameVar;
    public Transform trans;
   
    public int buttonCount;
    int _index=0;
    public void GenerateButtonOnClick(int index)
    {
        //int _index = 0;
        nameVar = galleries[index].galleryName;
        UnityEvent onClick = galleryButtons[index].GetComponent<Button>().onClick;
        _index = index;
        int a = _index;
        string ab = "sfasf";
        //var  targetInfo = UnityEvent.GetValidMethodInfo(managerUI.ChangeText(portraitCanvas.transform.GetChild(1).GetChild(0), galleries[0].galleryName), "ChangeText", new System.Type[] { typeof(Transform), typeof(string)});
        //  UnityAction methodDelegate = System.Delegate.CreateDelegate(typeof(UnityAction), managerUI, targetInfo) as UnityAction;
        // UnityEventTools.AddPersistentListener(onClick, methodDelegate);
        // UnityEventTools.RegisterPersistentListener(onClick, 0,delegate { UIManager.OpenPanel(managerUI.currentGalleryPortraitPanel); });
        // UnityEventTools.RegisterPersistentListener(onClick, 1, delegate { managerUI.OpenPanel(portraitCanvas.transform.GetChild(1)); });
        //UnityEventTools.RegisterPersistentListener(onClick, 2, () =>  managerUI.ChangeText(portraitCanvas.transform.GetChild(1).GetChild(0), "asdas"));

        ButtonGenerator generator = galleryButtons[index].gameObject.AddComponent<ButtonGenerator>();
        generator.gallery = galleries[index];
        generator.portraitCanvas = portraitCanvas;
        generator.text = portraitCanvas.transform.GetChild(1).GetChild(0).GetComponent<Text>();
       generator.galleryName= galleries[index].galleryName;
        generator.Generate();
        // UnityEventTools.RegisterPersistentListener(onClick, 3, delegate { managerUI.ClosePanel(portraitCanvas.transform.GetChild(0)); });

    }

    public void CreateGallaryPanel(Gallery gal)
    {
        
      
        gal.portraitPanel= Instantiate(galleryPanelPrefab) as GameObject;
        //gal.portraitPanel.transform.SetParent(portraitCanvas.transform.GetChild(1));
        RectTransform trans = gal.portraitPanel.GetComponent<RectTransform>();
        gal.portraitPanel.GetComponent<RectTransform>().parent = portraitCanvas.transform.GetChild(1).GetComponent<RectTransform>();
        gal.portraitPanel.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        gal.portraitPanel.GetComponent<RectTransform>().offsetMax = new Vector2(0, 90);
        gal.portraitPanel.transform.localScale = new Vector3(1, 1, 1);
        gal.portraitPanel.SetActive(false);
        gal.portraitPanel.name = "GalleryPanel";


    }

    public void CreateGallaryButton(Gallery gal)
    {
        GameObject obj = Instantiate(galleryButtonPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        obj.transform.SetParent(portraitCanvas.transform.GetChild(0).GetChild(0).GetChild(0));
        obj.gameObject.transform.SetAsLastSibling();
        obj.transform.localScale = new Vector3(1, 1, 1);
        galleryButtons.Add(obj);
        obj.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = gal.galleryName;
        obj.GetComponent<Image>().sprite = gal.galleryAvatar;
        justifyGalleries();
        GenerateButtonOnClick(galleries.IndexOf(gal));
    }

    public void CreateGallaryButtons()
    { /*
        for (int i = 0; i < buttonCount; i++)
        {
            if (i < galleriesCount)
            {
                galleryButtons.Add(GameObject.FindGameObjectsWithTag("portGalButt")[i]);
                
            }
            else DestroyImmediate(GameObject.FindGameObjectsWithTag("portGalButt")[i]);
        }

        for (int i = buttonCount; i < galleriesCount; i++)
        {
            GameObject obj = Instantiate(galleryButtonPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            obj.transform.SetParent(portraitCanvas.transform.GetChild(0).GetChild(0).GetChild(0));
            obj.transform.localScale = new Vector3(1, 1, 1);
            galleryButtons.Add(obj);
            
        }
        for (int i = 0; i < galleriesCount; i++)
        {

            galleries[i].gameObject.name = "Gallery " + galleries[i].galleryName;
            galleryButtons[i].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = galleries[i].galleryName;
            galleryButtons[i].GetComponent<Image>().sprite = galleries[i].galleryAvatar;
        }
        for (int i = 0;i < galleriesCount;i++)
        {
           GenerateButtonOnClick(i);
        }*/

        for (int i = 0; i < galleriesCount; i++)
        {
            GameObject obj = Instantiate(galleryButtonPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            obj.transform.SetParent(portraitCanvas.transform.GetChild(0).GetChild(0).GetChild(0));
            obj.transform.localScale = new Vector3(1, 1, 1);
            galleryButtons.Add(obj);
            galleries[i].gameObject.name = "Gallery " + galleries[i].galleryName;
            galleryButtons[i].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = galleries[i].galleryName;
            galleryButtons[i].GetComponent<Image>().sprite = galleries[i].galleryAvatar;
            foreach (var button in GameObject.FindGameObjectsWithTag("portGalButt"))
            {

                if (obj.GetComponent<Gallery>().id == i)
                    galleryButtons.Add(obj);
            }
        }
    }

    public void AddNewGallery(string name, Sprite avatar, float price)
    {
        GameObject obj = new GameObject();
        obj.transform.SetParent(gameObject.transform);
        obj.AddComponent<Gallery>().id = galleries.Count;
        obj.tag = "gallery";
        obj.GetComponent<Gallery>().galleryName = name;
        obj.GetComponent<Gallery>().galleryAvatar = avatar;
        obj.GetComponent<Gallery>().price = price;
        obj.gameObject.name = "Gallery " + name;
        

        CreateGallaryPanel(obj.GetComponent<Gallery>());
        CreateGallaryButton(obj.GetComponent<Gallery>());
        Renew();
       
    }
   

    public void justifyGalleries()
    {
        galleries.Clear();
        foreach (var obj in GameObject.FindGameObjectsWithTag("gallery"))
        {
            galleriesCount++;
        }

        for (int i = 0; i < galleriesCount; i++)
        {
            
            foreach (var obj in GameObject.FindGameObjectsWithTag("gallery"))
            {
               
                if ( obj.GetComponent<Gallery>().id==i)
                galleries.Add(obj.GetComponent<Gallery>()); 
            }
        }
    }

    public void justifyButtons()
    {
        galleryButtons.Clear();

        for (int i = 0; i < galleriesCount; i++)
        {

            foreach (var obj in GameObject.FindGameObjectsWithTag("portGalButt"))
            {

                if (obj.transform.GetSiblingIndex() == i)
                    galleryButtons.Add(obj);
            }
        }
    }

    public void Renew()
    {
        portraitCanvas = GameObject.FindWithTag("portraitCanvas");
        galleriesCount = 0;
        galleries.Clear();
        galleryButtons.Clear();
        buttonCount = GameObject.FindGameObjectsWithTag("portGalButt").Length;

        justifyGalleries();
        justifyButtons();
       // CreateGallaryButtons();
       // GenerateButtonOnClick(0);
      
        
     
       
    }


}
