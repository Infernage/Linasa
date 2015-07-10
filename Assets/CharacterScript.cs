using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {
    public float max = 5;
    public float force = 0.01F;
    public float accelerationV = 0, accelerationH = 0;
    public float health = 3;
    public float oxygen = 500;
    public float distanceUp
    {
        set;
        get;
    }
    public float distanceDown
    {
        set;
        get;
    }
    public float distanceRight
    {
        set;
        get;
    }
    public float distanceLeft
    {
        set;
        get;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (v == -1 && accelerationV > 0 - max)
        {
            accelerationV -= force * (accelerationV > 0 ? 2 : 1);
        }
        if (v == 1 && accelerationV < max)
        {
            accelerationV += force * (accelerationV < 0 ? 2 : 1);
        }
        if (h == -1 && accelerationH > 0 - max)
        {
            accelerationH -= force * (accelerationH > 0 ? 2 : 1);
        }
        if (h == 1 && accelerationH < max)
        {
            accelerationH += force * (accelerationH < 0 ? 2 : 1);
        }
        if (v == 0 && accelerationV != 0)
        {
            accelerationV = accelerationV > 0 ? accelerationV - force : accelerationV + force;
        }
        if (h == 0 && accelerationH != 0)
        {
            accelerationH = accelerationH > 0 ? accelerationH - force : accelerationH + force;
        }
        float hdistance = accelerationH * Time.deltaTime;
        float vdistance = accelerationV * Time.deltaTime;
        transform.Translate(Vector3.right * hdistance);
        transform.Translate(Vector3.up * vdistance);
        if (v != 0 || h != 0)
        {
            oxygen -= force * 10;
        }
        else
        {
            oxygen -= force;
        }
        if (oxygen <= 0)
        {
            Debug.Break(); // TODO: Game over
        }
        if (accelerationH > 0)
        {
            distanceRight += Mathf.Abs(accelerationH);
        }
        else
        {
            distanceLeft += Mathf.Abs(accelerationH);
        }
        if (accelerationV > 0)
        {
            distanceUp += Mathf.Abs(accelerationV);
        }
        else
        {
            distanceDown += Mathf.Abs(accelerationV);
        }
	}

    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Obstacle"))
        {
            health--;
            if (health <= 0)
            {
                Debug.Break(); // TODO: Game over
            }
        }
        else if (collision.gameObject.tag.Equals("Point"))
        {
            PuntuationManager puntuation = GetComponent<PuntuationManager>();
            puntuation.forward(collision);
        }
    }
}
