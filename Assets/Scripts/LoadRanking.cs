using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System;

public class LoadRanking : MonoBehaviour
{


    private Text texto;

    // Use this for initialization
    void Start()
    {
        texto = this.GetComponentInChildren<Text>();

        LoadData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadData()
    {
        string[] ranking = File.ReadAllLines(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Assets" + Path.DirectorySeparatorChar + "Ranking" + Path.DirectorySeparatorChar + "Ranking.txt");
        
        List<KeyValuePair<int, string>> ordenada = new List<KeyValuePair<int, string>>();
        for (int i = 0; i < ranking.Length; i++)
        {
            string[] cut = ranking[i].Split('-');
            KeyValuePair<int, string> key = new KeyValuePair<int, string>(int.Parse(cut[1]), cut[0]);
            ordenada.Add(key);
        }

        ordenada.Sort((x, y) => x.Key.CompareTo(y.Key));
        ordenada.Reverse();
        foreach (KeyValuePair<int, string> kvp in ordenada)
        {
            texto.text += kvp.Value + "  " + kvp.Key + "\n";
        }
    }
}
