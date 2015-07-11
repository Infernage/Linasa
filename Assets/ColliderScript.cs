using UnityEngine;
using System.Collections;

public class ColliderScript : MonoBehaviour {
    public CharacterScript character;
    public bool subLife = true;
    public float health = 3;
    public PuntuationManager puntuation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            if (!subLife) subLife = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            if (subLife)
            {
                subLife = false;
                health--;
                if (health <= 0)
                {
                    Application.LoadLevel("ranking");
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Point"))
        {
            puntuation.forward(collision);
        }
        else if (collision.gameObject.tag == "Oxygen")
        {
            Destroy(collision.gameObject);
            GenItems.items--;
            character.oxygen += 200;
            if (character.oxygen > 600) character.oxygen = 600;
        }
    }
}
