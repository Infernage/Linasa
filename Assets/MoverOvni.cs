using UnityEngine;
using System.Collections;

public class MoverOvni : MonoBehaviour
{

    private float tiempo;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        //if (tiempo >= 1)
        //{
            this.transform.position = Vector3.left * 6*Time.deltaTime;
            tiempo = 0;
       // }
    }
}
