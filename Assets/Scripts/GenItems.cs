using UnityEngine;
using System.Collections;

public class GenItems : MonoBehaviour
{
    private GameObject[] objs = new GameObject[7];
    private int num = 0;
    public static readonly int maxItems = 20;
    public static int items = 0;

    // Use this for initialization
    void Start()
    {
        objs[0] = Resources.Load("Ovni", typeof(GameObject)) as GameObject;
        objs[1] = Resources.Load("Satelite", typeof(GameObject)) as GameObject;
        objs[2] = Resources.Load("Asteroide", typeof(GameObject)) as GameObject;
        objs[3] = Resources.Load("Barril", typeof(GameObject)) as GameObject;
        objs[4] = Resources.Load("BolsaBasura", typeof(GameObject)) as GameObject;
        objs[5] = Resources.Load("Bombona", typeof(GameObject)) as GameObject;
        objs[6] = Resources.Load("Meteoro", typeof(GameObject)) as GameObject;
        FirstGen();
    }
    void FirstGen()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (items < maxItems) GenItem();
    }

    void GenItem()
    {
        num = Random.Range(0, objs.Length);
        float x = Random.Range(0, 2) + transform.position.x;
        float y = Random.Range(0, 2) + transform.position.y;
        Instantiate(objs[num], new Vector3(x, y, transform.position.z), Quaternion.identity);
        items++;
    }



}
