﻿using UnityEngine;
using System.Collections;

public class Ranking : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        GameObject.Find("PuntuacionesUI").SetActive(true);
    }
}
