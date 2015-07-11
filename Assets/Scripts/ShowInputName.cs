using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class ShowInputName : MonoBehaviour
{
    private bool top10 = false;
    private float points;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (top10)
        {
            this.enabled = true;
        }
    }

    void ComprobarTop10(float points)
    {
        //Get all lines in ranking
        string[] lines = File.ReadAllLines("\\Ranking\\Ranking.txt");

        for (int i = 0; i < lines.Length; i++)
        {
            // Split the line by '-'
            string[] cut = lines[i].Split('-');
            if (int.Parse(cut[1]) < points && !top10)
            {
                top10 = true;
                this.points = points;
            }
        }
    }

}
