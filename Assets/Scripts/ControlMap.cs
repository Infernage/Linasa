﻿using UnityEngine;
using System.Collections;

public class ControlMap : MonoBehaviour
{

    public GameObject contenedor;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            contenedor.SetActive(true);
        }
    }
}
