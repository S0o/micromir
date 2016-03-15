using UnityEngine;
using System.Collections;

public class Gallery : MonoBehaviour {

    public int id;
    public string galleryName;
    public double price;
    public int photosCount;
    public Sprite galleryAvatar;
    public Photo[] photos;
    public ListOfGalleries galleries;

    public void GalleryRenew()
    {
        Debug.Log(2);
    }
    void Update()
    {
        Debug.Log(1);
    }
}
