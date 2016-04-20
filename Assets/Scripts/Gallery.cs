using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor.Events;
#endif 
using UnityEngine.Events;

public class Gallery : MonoBehaviour
{

    public int id;
    public string galleryName;
    public float price;
    public int photosCount;
    public Sprite galleryAvatar;
    public List <Photo> photos= new List<Photo>();
    public List<GameObject> buttons = new List<GameObject>();
    public ListOfGalleries listOfGallaries;
    public GameObject portraitPanel;
    public GameObject landscapePanel;

#if UNITY_EDITOR
    public void DeleteGallery()
    {
        id = 99999;
        Renew();
        gameObject.tag = "Untagged";
        DestroyImmediate(listOfGallaries.galleryButtons[id].gameObject);
        listOfGallaries.Renew();
       
        DestroyImmediate(portraitPanel);
        DestroyImmediate(gameObject);
    }
    public void ObjSort()
    {
     
        for (int i = 0; i < listOfGallaries.galleries.Count; i++)
        {
            listOfGallaries.galleries[i].gameObject.transform.SetSiblingIndex(listOfGallaries.galleries[i].id);
            listOfGallaries.galleryButtons[i].gameObject.transform.SetSiblingIndex(listOfGallaries.galleries[i].id);
        }
    }

    public void Sort()
    {
       
        if (id >= listOfGallaries.galleries.Count)   id = listOfGallaries.galleries.Count - 1;
        else if (id <0)   id = 0;

        int idNext = id;
        int idCurrent=0;
       
        id = -1;

        for(int i = 0;i < listOfGallaries.galleries.Count;i++)
        {
            if (listOfGallaries.galleries[i] == this)
            {
                idCurrent = i; 
                break;
            }
        }

        for (int i = 0; i < listOfGallaries.galleries.Count; i++)
        {
            if (i == idCurrent) continue;
            if (i > idCurrent && i<=idNext)
                listOfGallaries.galleries[i].id--;
            if (i >= idNext && i < idCurrent)
            {
                listOfGallaries.galleries[i].id++;
            }
        }
        id = idNext;
        ObjSort();
    }
    public void AddNewPhoto(string name, Sprite avatar, Sprite image)
    {
        Initialisation();
        GameObject obj = new GameObject();
        obj.transform.SetParent(gameObject.transform);
        obj.AddComponent<Photo>().id = photos.Count;
        obj.tag = "photo";
        obj.GetComponent<Photo>().photoName = name;
        obj.GetComponent<Photo>().avatar = avatar;
        obj.GetComponent<Photo>().image = image;
        obj.GetComponent<Photo>().gallery = this;
        obj.gameObject.name = name;
        justifyPhotos();
        CreatePhotoButton(obj.GetComponent<Photo>());

        Renew();

    }

    public void buttonRenew(GameObject buttObj)
    {
        Photo photo = photos[buttons.IndexOf(buttObj)];
        buttObj.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = photo.photoName;
        buttObj.GetComponent<Image>().sprite = photo.avatar;
    }
    public void CreatePhotoButton(Photo photo)
    {
        GameObject obj = Instantiate(listOfGallaries.photoButtonPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        obj.tag = "portPhotButt";
        obj.transform.SetParent(portraitPanel.transform.GetChild(0).GetChild(0));
        obj.gameObject.transform.SetAsLastSibling();
        obj.transform.localScale = new Vector3(1, 1, 1);
        buttons.Add(obj);
        obj.transform.GetChild(0).GetChild(0).GetComponent<Text>().text =photo.name;
        obj.GetComponent<Image>().sprite = photo.avatar;
        obj.GetComponent<PhotoButton>().photo = photo;
        obj.GetComponent<PhotoButton>().gallery = this;
        obj.GetComponent<PhotoButton>().portraitCanvas = listOfGallaries.portraitCanvas;
        obj.GetComponent<PhotoButton>().name = photo.name;
        obj.GetComponent<PhotoButton>().photoViewer = listOfGallaries.photoViewer;

    }
    public void GenerateButtonOnClick(int index)
    {
        UnityEvent onClick = buttons[index].GetComponent<Button>().onClick;

 
      /*  ButtonGenerator generator = buttons[index].gameObject.AddComponent<ButtonGenerator>();
        generator.photo = photos[index];
        generator.gallery = this;
        generator.portraitCanvas = listOfGallaries.portraitCanvas;
        generator.name = photos[index].name;
        generator.photoViewer = listOfGallaries.photoViewer;
        generator.GeneratePhoto();*/

    }
 
    public void Initialisation()
    {
        listOfGallaries = transform.parent.GetComponent<ListOfGalleries>();
    }

    public void Renew()
    {
        photosCount = 0;
        Initialisation();
        Sort();
        justifyPhotos();
        justifyButtons();
        listOfGallaries.Renew();
        
    }

    public void justifyPhotos()
    {
        photosCount = 0;
        photos.Clear();
        foreach (var obj in GameObject.FindGameObjectsWithTag("photo"))
        {
            if(obj.GetComponent<Photo>().gallery==this)
            photosCount++;
        }

        for (int i = 0; i < photosCount; i++)
        {

            foreach (var obj in GameObject.FindGameObjectsWithTag("photo"))
            {

                if ((obj.GetComponent<Photo>().gallery == this) && (obj.GetComponent<Photo>().id == i))
                {
                    photos.Add(obj.GetComponent<Photo>());
                    obj.name = obj.GetComponent<Photo>().photoName;
                }
            }
        }
    }
    public void justifyButtons()
    {
        
        buttons.Clear();

        for (int i = 0; i < photosCount; i++)
        {
          
            foreach (Button obj in Resources.FindObjectsOfTypeAll(typeof(Button))as Button[])
            {

                GameObject gObj = obj.gameObject;
                
                if  (gObj.tag== "portPhotButt") 
                    if ((gObj.transform.GetSiblingIndex() == i)
                   && (gObj.GetComponent<PhotoButton>().gallery == this)
                    )
                 
                        buttons.Add(gObj);

              
            }
            foreach (var obj in buttons)
            {
                buttonRenew(obj);
            }
        }
    }
#endif 
}

