using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Gallery : MonoBehaviour, ISerializationCallbackReceiver
{
    public Sprite galleryAvatar;
    public string galleryName;
    public string galleryInfo;
    public GalleryButton galleryButton;

    public Transform textTransf;
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


}
