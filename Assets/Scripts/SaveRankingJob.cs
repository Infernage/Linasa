using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class SaveRankingJob : Job
{
    private string n;
    private string[] s;
    public SaveRankingJob(string name, string[] split)
    {
        n = name;
        s = split;
    }

    protected override void RunImpl()
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
        saveRanking.Add(n + "-" + s[1]);
        string[] array = (string[])saveRanking.ToArray(typeof(string));
        File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        + Path.DirectorySeparatorChar + "Linasa" + Path.DirectorySeparatorChar + "Ranking.txt", array);
    }
}
