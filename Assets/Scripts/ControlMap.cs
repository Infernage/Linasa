﻿using UnityEngine;
using System.Collections;

public class ControlMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0)){
            Application.LoadLevel("Control");
        }
    }
}
