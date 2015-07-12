using UnityEngine;
using System.Collections;

public class MoverItem : MonoBehaviour
{
    public Vector3 direction;
    public bool random;
    public float speed;
    // Use this for initialization
    void Start()
    {
        if (random) direction = new Vector3(Random.Range(-1F, 1F), Random.Range(-1F, 1F), 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
