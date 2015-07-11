using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class ShowInputName : MonoBehaviour
{
    private Text pointsText;

    // Use this for initialization
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        pointsText = canvas.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ComprobarTop10()
    {
        string[] split = pointsText.text.Split(' ');
        float points = int.Parse(split[1]);
        //Get all lines in ranking
        string[] lines = File.ReadAllLines(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Assets" + Path.DirectorySeparatorChar + "Ranking" + Path.DirectorySeparatorChar + "Ranking.txt");

        for (int i = 0; i < lines.Length; i++)
        {
            // Split the line by '-'
            string[] cut = lines[i].Split('-');
            if (int.Parse(cut[1]) < points)
            {
                this.enabled = true;
            }
        }
    }

}
