using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

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
        for (int i = 0; i < ranking.Length; i++)
        {
            string[] cut = ranking[i].Split('-');
            texto.text += cut[0].ToString() + "" + cut[1].ToString() + "\n";
        }
    }
}
