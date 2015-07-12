using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System;

public class SaveRanking : MonoBehaviour
{
    private InputField InputName;
    private Text points;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }


    public void SaveData()
    {
        GameObject canvas = GameObject.Find("Canvas");
        points = canvas.GetComponentInChildren<Text>();
        InputName = canvas.GetComponentInChildren<InputField>();
        string name = InputName.text;
        string[] split = points.text.Split(' ');
        if (name != null && name != "")
        {
            new SaveRankingJob(name, split).Start();
        }
        Application.LoadLevel("menu");
    }
}
