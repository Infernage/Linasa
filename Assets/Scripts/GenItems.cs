using UnityEngine;
using System.Collections;

public class GenItems : MonoBehaviour
{
    public GameObject[] objs = new GameObject[2];
    private int num = 0;

    // Use this for initialization
    void Start()
    {
        objs[0] = (GameObject)Resources.Load("sfdfsdfsd");
    }

    // Update is called once per frame
    void Update()
    {
        GenItem();

    }

    void GenItem()
    {
        num = Random.Range(0, objs.Length);
        Instantiate(objs[num], transform.position, Quaternion.identity);
    }



}
