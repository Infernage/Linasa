using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System;

public class LoadRanking : MonoBehaviour
{


    private Text texto;
    private LoadRankingJob job;

    // Use this for initialization
    void Start()
    {
        texto = this.GetComponent<Text>();
        job = new LoadRankingJob();
        job.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (job != null)
        {
            if (job.Update())
            {
                List<KeyValuePair<int, string>> ordenada = job.Result;
                int cont = 0;
                foreach (KeyValuePair<int, string> kvp in ordenada)
                {
                    if (cont < 10)
                    {
                        texto.text += kvp.Value + "  " + kvp.Key + "\n";
                        cont++;
                    }
                }
                job = null;
            }
        }
    }
}
