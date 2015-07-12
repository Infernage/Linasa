using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

class LoadRankingJob : Job
{
    private List<KeyValuePair<int, string>> ordenada = null;
    public List<KeyValuePair<int, string>> Result
    {
        get
        {
            List<KeyValuePair<int, string>> tmp;
            lock (handle)
            {
                tmp = ordenada;
            }
            return tmp;
        }
    }

    override
    protected void RunImpl()
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

        ordenada = new List<KeyValuePair<int, string>>();
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
    }
}
