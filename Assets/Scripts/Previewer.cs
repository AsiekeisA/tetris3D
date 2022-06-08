﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Previewer : MonoBehaviour
{
    public static Previewer instance;

    public GameObject[] previewBlocks;

    GameObject ActiveObj;
    void Awake()
    {
        instance = this;
    }
    public void ShowPreview(int index)
    {
        Destroy(ActiveObj);
        ActiveObj = Instantiate(previewBlocks[index], transform.position, Quaternion.identity) as GameObject;
    }
}
