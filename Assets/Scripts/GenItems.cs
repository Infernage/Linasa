using UnityEngine;
using System.Collections;

public class GenItems : MonoBehaviour
{
    private GameObject[] objs = new GameObject[7];
    private int num = 0;
    public static readonly int maxItems = 20;
    public static int items = 0;
    public static bool generate = true;

    // Use this for initialization
    void Start()
    {
        generate = true;
        objs[0] = Resources.Load("Ovni", typeof(GameObject)) as GameObject;
        objs[1] = Resources.Load("Satelite", typeof(GameObject)) as GameObject;
        objs[2] = Resources.Load("Asteroide", typeof(GameObject)) as GameObject;
        objs[3] = Resources.Load("Barril", typeof(GameObject)) as GameObject;
        objs[4] = Resources.Load("BolsaBasura", typeof(GameObject)) as GameObject;
        objs[5] = Resources.Load("Bombona", typeof(GameObject)) as GameObject;
        objs[6] = Resources.Load("Meteoro", typeof(GameObject)) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (items < maxItems && generate) GenItem();
    }

    void GenItem()
    {
        num = Random.Range(0, objs.Length);
        float x = Random.Range(0, 2) + transform.position.x;
        float y = Random.Range(0, 2) + transform.position.y;
        Vector3 pos = new Vector3(x, y, transform.position.z);
        if (Physics2D.OverlapCircleAll(new Vector2(x, y), 5).Length == 0)
        {
            GameObject item = Instantiate(objs[num], pos, Quaternion.identity) as GameObject;
            item.transform.parent = GameObject.Find("Objects").transform;
            items++;
        }
    }

    void OnDestroy()
    {
        items = 0;
    }
}
