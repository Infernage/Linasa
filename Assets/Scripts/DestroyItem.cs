using UnityEngine;
using System.Collections;

public class DestroyItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(transform.position.x + " " + transform.position.y);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
        GenItems.items--;
        //Debug.Log("Destroy trigger");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
        GenItems.items--;
        Debug.Log("Destroy trigger");
    }
}
