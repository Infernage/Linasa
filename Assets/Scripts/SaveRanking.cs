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
        GameObject canvas = GameObject.Find("CanvasTop10");
        GameObject canvasPoints = GameObject.Find("Canvas");
        points = canvasPoints.GetComponent<Text>();
        InputName = canvas.GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
    }


   public void SaveData() {
        string name = InputName.text;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click!");
            if (name != null && name != "")
            {
                Debug.Log("Leer ranking");
                string[] ranking = File.ReadAllLines("\\Ranking\\Ranking.txt");
                string[] saveRanking = new string[10];
                saveRanking = ranking;
                saveRanking[10] = name + "-" + /*points.text*/10;
                Array.Sort(saveRanking);
                File.WriteAllLines("\\Ranking\\Ranking.txt", saveRanking);
            }
        }
    }
}
