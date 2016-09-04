using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class UIcontroller : MonoBehaviour {

    public Transform viewer;
    public GameObject galleryPrefab;
    public GameObject subGalleryPrefab;
    public GameObject galleryButtonPrefab;
    public GameObject subGalleryButtonPrefab;
    public GameObject PhotoButtonPrefab;
    public Transform portraitList;
    public Transform portraitListContent;
    public Transform gallariesTransform;
    public Transform subGallariesTransform;
    public Transform viewerTopText;
    public LanguageManager languageManager;
    public float topHeight = 70f;
    public Sprite defaultSprite;

    public void GenerateGallaryButton(Gallery gallery)
    {
        GameObject butt = Instantiate(galleryButtonPrefab) as GameObject;
        butt.transform.SetParent(portraitListContent);
        butt.GetComponent<GalleryButton>().galleryPanel = gallery.transform;
        butt.GetComponent<Image>().sprite = gallery.galleryAvatar;
        gallery.galleryButton = butt.GetComponent<GalleryButton>();
    }


    public void GenerateSubGallaryButton(SubGallery subGallery)
    {
        GameObject butt = Instantiate(subGalleryButtonPrefab) as GameObject;
        butt.transform.SetParent(subGallery.gallery.transform.GetChild(0).GetChild(0));
        butt.GetComponent<SubGalleryButton>().subGalleryPanel = subGallery.transform;
        butt.GetComponent<Image>().sprite = subGallery.subGalleryAvatar;
        subGallery.subGalleryButton = butt.GetComponent<SubGalleryButton>();
    }

    public void GeneratePhotoButton( SubGallery subGallery, string photopath)
    {
        GameObject butt = Instantiate(PhotoButtonPrefab) as GameObject;
        butt.transform.SetParent(subGallery.transform.GetChild(0).GetChild(0));            
        setPhoto(butt.GetComponent<Photo>(), subGallery, photopath);
        butt.GetComponent<PhotoButton>().photo = butt.GetComponent<Photo>();
        butt.GetComponent<Image>().sprite = butt.GetComponent<Photo>().photoAvatar;
        butt.GetComponent<Photo>().photoButton = butt.GetComponent<PhotoButton>();

    }

    public Sprite LoadPhoto(string dirName)
    {

        
        Texture2D texture = new Texture2D(100, 100);
        if (Directory.GetFiles(dirName, "*.jpg").Length>0)
           {
            texture.LoadImage(File.ReadAllBytes(Directory.GetFiles(dirName, "*.jpg")[0]));
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(.5f, .5f));
          }
        else return defaultSprite;
    }
    public Sprite LoadPhoto(string dirName, string photoName)
    {


        Texture2D texture = new Texture2D(100, 100);
        if (Directory.GetFiles(dirName, photoName).Length > 0)
        {
            texture.LoadImage(File.ReadAllBytes(Directory.GetFiles(dirName, photoName)[0]));
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(.5f, .5f));
        }
        else return defaultSprite;
    }

    public void setPhoto(Photo photo,SubGallery subGallery, string dirName)
    {
        photo.photoAvatar = LoadPhoto(dirName,"Avatar.jpg");
        photo.photo = LoadPhoto(dirName, "Photo.jpg");
        photo.subGallery = subGallery;
        photo.languages.Clear();//Для адекватной прездагрузки языка
                                                          //языки
        languageManager.listOfPhoto.Add(photo);
        string dictionary = File.ReadAllText(dirName + "/Photo.xml");
        languageManager.PhotoReader(dictionary, photo);
    }
    public void setSubGallery(SubGallery subGallery, string dirName)
    {
        subGallery.subGalleryAvatar = LoadPhoto(dirName);
        GenerateSubGallaryButton(subGallery);
        foreach (string photopath in Directory.GetDirectories(dirName))
        {
           GeneratePhotoButton(subGallery, photopath);
           
        }
    }

    public void setGallery(Gallery gallery, string dirName)
    {     
        gallery.galleryAvatar=LoadPhoto(dirName);
        GenerateGallaryButton(gallery);
    }


    public void GenerateGallery(string dirName)
    {
        //Копирование и настройка префаба
        GameObject gal = Instantiate(galleryPrefab, gallariesTransform) as GameObject;
        gal.name = dirName;
        RectTransform rect = gal.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(0, 0);
        rect.offsetMax = new Vector2(0, -topHeight);
        rect.offsetMin = new Vector2(0, 0);

        gal.SetActive(false);
        setGallery(gal.GetComponent<Gallery>(), dirName);
        GenerateSubGalleries(gal.GetComponent<Gallery>(), dirName);

        gal.GetComponent<Gallery>().languages.Clear();//Для адекватной прездагрузки языка
        //языки
        languageManager.listOfGallaries.Add(gal.GetComponent<Gallery>());
        string dictionary = File.ReadAllText(dirName + "/Gallery.xml");
        languageManager.GalleryReader(dictionary, gal.GetComponent<Gallery>());
    }

    public void GenerateSubGalleries(Gallery gallery, string dirName)
    {
        foreach (string subDirName in Directory.GetDirectories(dirName))
        {
            //Копирование и настройка префаба
            GameObject sgal = Instantiate(subGalleryPrefab) as GameObject;
            sgal.transform.SetParent(subGallariesTransform);
            RectTransform rect = sgal.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(0, 0);
            rect.offsetMax = new Vector2(0, -topHeight);
            rect.offsetMin = new Vector2(0, 0);

            sgal.SetActive(false);
            sgal.GetComponent<SubGallery>().gallery = gallery;
            setSubGallery(sgal.GetComponent<SubGallery>(), subDirName);

            sgal.GetComponent<SubGallery>().languages.Clear();//Для адекватной прездагрузки языка
            //языки
            languageManager.listOfSubGallaries.Add(sgal.GetComponent<SubGallery>());
            string dictionary = File.ReadAllText(subDirName + "/Subgallery.xml");
            languageManager.SubGalleryReader(dictionary, sgal.GetComponent<SubGallery>());


        }
    }


    public void ClosePanel(Transform panel)
    {
        panel.gameObject.SetActive(false);
    }

    public void OpenPanel(Transform panel)
    {
        panel.gameObject.SetActive(true);
    }

    public void OpenViewer(Photo photo)
    {
        OpenPanel(viewer);
        viewerTopText.GetComponent<Text>().text = photo.photoName;
        GameObject.FindGameObjectWithTag("PhotoOnViewer").GetComponent<Image>().sprite=photo.photo;

    }
}
