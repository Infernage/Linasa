using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColliderScript : MonoBehaviour
{
    public CharacterScript character;
    public bool subLife = true;
    public float health = 3;
    public PuntuationManager puntuation;
    public AudioClip pointUp;
    public AudioClip oxygen;
    public AudioClip HitSat;
    public AudioClip[] audiosAlien;
    public AudioClip ouch;
    public AudioClip asteroidSound;
    public GameObject submitRanking;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
            AudioSource.PlayClipAtPoint(ouch, this.transform.position);
            if (collision.gameObject.name == "Satelite(Clone)")
            {
                AudioSource.PlayClipAtPoint(HitSat, this.transform.position);
            }
            else if (collision.gameObject.name == "Ovni(Clone)")
            {
                int num = Random.Range(0, audiosAlien.Length - 1);
                AudioClip clip = audiosAlien[num];
                AudioSource.PlayClipAtPoint(clip, this.transform.position);
                Bocadillo obj = collision.gameObject.GetComponent<Bocadillo>();
                obj.activar();
            }
            else if (collision.gameObject.name == "Asteroide(Clone)")
            {
                AudioSource.PlayClipAtPoint(asteroidSound, this.transform.position);
            }
            if (subLife)
            {
                subLife = false;
                health--;
                if (health <= 0)
                {
                    GenItems.generate = false;
                    Cursor.visible = true;
                    Destroy(GameObject.Find("Objects"));
                    character.finishInput = true;
                    submitRanking.SetActive(true);
                    InputField field = submitRanking.GetComponentInChildren<InputField>();
                    EventSystem.current.SetSelectedGameObject(field.gameObject, null);
                    field.OnPointerClick(new PointerEventData(EventSystem.current));
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Point"))
        {
            puntuation.forward(collision);
            AudioSource.PlayClipAtPoint(pointUp, this.transform.position);
        }
        else if (collision.gameObject.tag == "Oxygen")
        {
            Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(oxygen, this.transform.position);
            GenItems.items--;
            character.oxygen += 200;
            if (character.oxygen > 600) character.oxygen = 600;
        }
    }
}
