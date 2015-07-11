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
        points = canvasPoints.GetComponentInChildren<Text>();
        InputName = canvas.GetComponentInChildren<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void SaveData()
    {
        string name = InputName.text;
        string[] split = points.text.Split(' ');
        if (name != null && name != "")
        {
            string[] ranking = File.ReadAllLines(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Assets" + Path.DirectorySeparatorChar + "Ranking" + Path.DirectorySeparatorChar + "Ranking.txt");
            string[] saveRanking = new string[10];
            saveRanking = ranking;
            saveRanking[ranking.Length - 1] = name + "-" + split[1];
            Array.Sort(saveRanking);
            File.WriteAllLines(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Assets" + Path.DirectorySeparatorChar + "Ranking" + Path.DirectorySeparatorChar + "Ranking.txt", saveRanking);
        }
    }
}
