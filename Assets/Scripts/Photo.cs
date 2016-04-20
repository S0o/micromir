using UnityEngine;
using System.Collections;

public class Photo : MonoBehaviour {

    public Sprite image;
    public Sprite avatar;
    public string photoName;
    public int id;
    public string label1;
    public string label2;
    public Gallery gallery;

    public void ObjSort()
    {

        for (int i = 0; i < gallery.photos.Count; i++)
        {
            gallery.photos[i].gameObject.transform.SetSiblingIndex(gallery.photos[i].id);
            gallery.buttons[i].gameObject.transform.SetSiblingIndex(gallery.photos[i].id);
        }
    }

    public void Sort()
    {

        if (id >= gallery.photos.Count) id = gallery.photos.Count - 1;
        else if (id < 0) id = 0;

        int idNext = id;
        int idCurrent = 0;

        id = -1;

        for (int i = 0; i < gallery.photos.Count; i++)
        {
            if (gallery.photos[i] == this)
            {
                idCurrent = i;
                break;
            }
        }

        for (int i = 0; i < gallery.photos.Count; i++)
        {
            if (i == idCurrent) continue;
            if (i > idCurrent && i <= idNext)
                gallery.photos[i].id--;
            if (i >= idNext && i < idCurrent)
            {
                gallery.photos[i].id++;
            }
        }
        id = idNext;
        ObjSort();
    }
    public void DeletePhoto()
    {
        id = 99999;
        Renew();
        gameObject.tag = "Untagged";
        DestroyImmediate(gallery.buttons[id].gameObject);
        gallery.Renew();

       
        DestroyImmediate(gameObject);
    }
    public void Renew()
    {
       // Initialisation();
       Sort();
       gallery.Renew();
    }
}
