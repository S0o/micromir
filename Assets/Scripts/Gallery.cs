using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Gallery : MonoBehaviour
{

    public int id;
    public string galleryName;
    public float price;
    public int photosCount;
    public Sprite galleryAvatar;
    public List <Photo> photos= new List<Photo>();
    public ListOfGalleries listOfGallaries;
    public GameObject portraitPanel;
    public GameObject landscapePanel;


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
       // foreach(var gallery in listOfGallaries.gallaries)
       // {
          //  gallery.gameObject.transform.SetSiblingIndex(gallery.id);
       // }
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
        GameObject obj = new GameObject();
        obj.transform.SetParent(gameObject.transform);
        obj.AddComponent<Photo>().id = photos.Count;
        obj.tag = "photo";
        obj.GetComponent<Photo>().photoName = name;
        obj.GetComponent<Photo>().avatar = avatar;
        obj.GetComponent<Photo>().image = image;
        obj.gameObject.name = name;


       // CreateGallaryPanel(obj.GetComponent<Gallery>());
       // CreatePhotoButton(obj.GetComponent<Gallery>());
       // Renew();

    }

    public void Initialisation()
    {
        listOfGallaries = transform.parent.GetComponent<ListOfGalleries>();
    }

    public void Renew()
    {
        Initialisation();
        Sort();
        listOfGallaries.Renew();
    }
 

}

