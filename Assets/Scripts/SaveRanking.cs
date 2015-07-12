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
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + Path.DirectorySeparatorChar + "Linasa"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) 
                    + Path.DirectorySeparatorChar + "Linasa");
            }
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + Path.DirectorySeparatorChar + "Linasa" + Path.DirectorySeparatorChar + "Ranking.txt"))
            {
                File.Create(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    + Path.DirectorySeparatorChar + "Linasa" + Path.DirectorySeparatorChar + "Ranking.txt").Close();
            }
            string[] ranking = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + Path.DirectorySeparatorChar + "Linasa" + Path.DirectorySeparatorChar + "Ranking.txt");
            ArrayList saveRanking = new ArrayList();
            saveRanking.AddRange(ranking);
            saveRanking.Add(name + "-" + split[1]);
            string[] array = (string[])saveRanking.ToArray(typeof(string));
            File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            + Path.DirectorySeparatorChar + "Linasa" + Path.DirectorySeparatorChar + "Ranking.txt", array);
        }
        Application.LoadLevel("menu");
    }
}
