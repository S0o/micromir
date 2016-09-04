﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Photo : MonoBehaviour, ISerializationCallbackReceiver
{
    public Sprite photo;
    public Sprite photoAvatar;
    public string photoName;
    public string photoInfo;
    public string photoLabel1;
    public string photoLabel2;
    public PhotoButton photoButton;
    public SubGallery subGallery;

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
