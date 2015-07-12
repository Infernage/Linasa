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
        texto = this.GetComponent<Text>();

        LoadData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadData()
    {
        string[] ranking;
        if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            + Path.DirectorySeparatorChar + "Linasa" + Path.DirectorySeparatorChar + "Ranking.txt"))
        {
            ranking = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + Path.DirectorySeparatorChar + "Linasa" + Path.DirectorySeparatorChar + "Ranking.txt");
        }
        else
        {
            ranking = new string[0];
        }

        List<KeyValuePair<int, string>> ordenada = new List<KeyValuePair<int, string>>();
        for (int i = 0; i < ranking.Length; i++)
        {
            string[] cut = ranking[i].Split('-');
            KeyValuePair<int, string> key = new KeyValuePair<int, string>(int.Parse(cut[1]), cut[0]);
            ordenada.Add(key);
        }

        for (int i = ordenada.Count; i < 10; i++)
        {
            KeyValuePair<int, string> key = new KeyValuePair<int, string>(0, "AAAAAAAAAAAAAAA");
            ordenada.Add(key);
        }

        ordenada.Sort((x, y) => x.Key.CompareTo(y.Key));
        ordenada.Reverse();
        int cont = 0;
        foreach (KeyValuePair<int, string> kvp in ordenada)
        {
            if (cont < 10)
            {
                texto.text += kvp.Value + "  " + kvp.Key + "\n";
                cont++;
            }
        }
    }
}
