using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;
using System;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour,ISerializationCallbackReceiver
{

    public enum language
    {
        english,
        russian
    }
    public language currentLanguage;
    public Transform appNameTrans;
    public string appName;
    public string appInfo;
    //langauges block
    public List<Dictionary<string, string>> languages = new List<Dictionary<string, string>>();
    public List<string> _keys = new List<string>();
    public List<string> _values = new List<string>();
    public int rawsCount;


    public void OnBeforeSerialize()
    {

        _keys.Clear();
        _values.Clear();
        rawsCount = 0;

        foreach (var dict in languages)
        {
            rawsCount = 0;
            foreach (var kvp in dict)
            {
                _keys.Add(kvp.Key);
                _values.Add(kvp.Value);
                rawsCount++;
            }
        }
    }

    public void OnAfterDeserialize()
    {

        languages.Clear();

        int dictCount = 0;
        int curRawCount = 0;
        languages.Add(new Dictionary<string, string>());
        for (int i = 0; i < _keys.Count; i++)
        {
            if (curRawCount == rawsCount)
            {
                languages.Add(new Dictionary<string, string>());
                dictCount++;
                curRawCount = 0;
            }
            curRawCount++;
            languages[dictCount].Add(_keys[i], _values[i]);
        }

    }

    Dictionary<string, string> obj;

   
    public List<Gallery> listOfGallaries = new List<Gallery>();
    public List<SubGallery> listOfSubGallaries = new List<SubGallery>();
    public List<Photo> listOfPhoto = new List<Photo>();
    public int a;
    public int b;
    public void ChangeLanguage()
    {
        //Debug.Log(languages.Count);
        foreach (Gallery gallery in listOfGallaries)
        {

            gallery.languages[(int)currentLanguage].TryGetValue("GalleryName", out gallery.galleryName);
            gallery.languages[(int)currentLanguage].TryGetValue("Info", out gallery.galleryInfo);
            gallery.textTransf.GetComponent<Text>().text= gallery.galleryName;
            gallery.galleryButton.textTransf.GetComponent<Text>().text = gallery.galleryName;   
        }
        foreach (SubGallery subGallery in listOfSubGallaries)
        {
            subGallery.languages[(int)currentLanguage].TryGetValue("SubGalleryName", out subGallery.subGalleryName);
            subGallery.languages[(int)currentLanguage].TryGetValue("Info", out subGallery.subGalleryInfo);
            subGallery.textTransf.GetComponent<Text>().text = subGallery.subGalleryName;
            subGallery.subGalleryButton.textTransf.GetComponent<Text>().text = subGallery.subGalleryName;
        }
        foreach (Photo photo in listOfPhoto)
        {
            photo.languages[(int)currentLanguage].TryGetValue("PhotoName", out photo.photoName);
            photo.languages[(int)currentLanguage].TryGetValue("Info", out photo.photoInfo);
            photo.languages[(int)currentLanguage].TryGetValue("Label1", out photo.photoLabel1);
            photo.languages[(int)currentLanguage].TryGetValue("Label2", out photo.photoLabel2);
            photo.photoButton.textTransf.GetComponent<Text>().text = photo.photoName;
        }


        languages[(int)currentLanguage].TryGetValue("AppName", out appName);
        languages[(int)currentLanguage].TryGetValue("AppInfo", out appInfo);
        appNameTrans.GetComponent<Text>().text = appName;
    }

    void Update()
    {

     
    }
    public void GalleryReader(string galleryDictionary,Gallery gallery)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(galleryDictionary);
        XmlNodeList languageList = xmlDoc.GetElementsByTagName("Language");
        foreach (XmlNode languageValue in languageList)
        {
            XmlNodeList languageContent = languageValue.ChildNodes;
            obj = new Dictionary<string, string>();

            foreach (XmlNode value in languageContent)
            {


                if (value.Name == "GalleryName")
                    obj.Add(value.Name, value.InnerText);

                if (value.Name == "Info")
                    obj.Add(value.Name, value.InnerText);
            }
         
            gallery.languages.Add(obj);        
        }
    }
    public void SubGalleryReader(string subGalleryDictionary, SubGallery subGallery)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(subGalleryDictionary);
        XmlNodeList languageList = xmlDoc.GetElementsByTagName("Language");
        foreach (XmlNode languageValue in languageList)
        {
            XmlNodeList languageContent = languageValue.ChildNodes;
            obj = new Dictionary<string, string>();

            foreach (XmlNode value in languageContent)
            {
             
                if (value.Name == "SubGalleryName")
                    obj.Add(value.Name, value.InnerText);

                if (value.Name == "Info")
                    obj.Add(value.Name, value.InnerText);
            }

            subGallery.languages.Add(obj);
        }
    }
    public void PhotoReader(string PhotoDictionary, Photo photo)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(PhotoDictionary);
        XmlNodeList languageList = xmlDoc.GetElementsByTagName("Language");
        foreach (XmlNode languageValue in languageList)
        {
            XmlNodeList languageContent = languageValue.ChildNodes;
            obj = new Dictionary<string, string>();

            foreach (XmlNode value in languageContent)
            {

                if (value.Name == "PhotoName")
                    obj.Add(value.Name, value.InnerText);

                if (value.Name == "Info")
                    obj.Add(value.Name, value.InnerText);

                if (value.Name == "Label1")
                    obj.Add(value.Name, value.InnerText);

                if (value.Name == "Label2")
                    obj.Add(value.Name, value.InnerText);

            }

            photo.languages.Add(obj);
        }
    }
        public void GlobalReader(string Dictionary)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(Dictionary);
        XmlNodeList languageList = xmlDoc.GetElementsByTagName("Language");
        foreach (XmlNode languageValue in languageList)
        {
            XmlNodeList languageContent = languageValue.ChildNodes;
            obj = new Dictionary<string, string>();

            foreach (XmlNode value in languageContent)
            {

                if (value.Name == "AppName")
                    obj.Add(value.Name, value.InnerText);

                if (value.Name == "AppInfo")
                    obj.Add(value.Name, value.InnerText);


            }

            languages.Add(obj);
        }
    }

}
