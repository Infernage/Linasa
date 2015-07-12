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
        Debug.Log(points.text);
        InputName = canvas.GetComponentInChildren<InputField>();
        string name = InputName.text;
        string[] split = points.text.Split(' ');
        if (name != null && name != "")
        {
            string[] ranking = File.ReadAllLines(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Assets" + Path.DirectorySeparatorChar + "Ranking" + Path.DirectorySeparatorChar + "Ranking.txt");
            ArrayList saveRanking = new ArrayList();
            saveRanking.AddRange(ranking);
            saveRanking.Add(name + "-" + split[1]);
            string[] array = (string[])saveRanking.ToArray(typeof(string));
            File.WriteAllLines(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Assets" + Path.DirectorySeparatorChar + "Ranking" + Path.DirectorySeparatorChar + "Ranking.txt", array);
        }
        Application.LoadLevel("menu");
    }
}
