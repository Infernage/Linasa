using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColliderScript : MonoBehaviour
{
    public CharacterScript character;
    public bool subLife = true;
    public PuntuationManager puntuation;
    public AudioClip pointUp;
    public AudioClip oxygen;
    public AudioClip HitSat;
    public AudioClip[] audiosAlien;
    public AudioClip ouch;
    public AudioClip asteroidSound;
    public AudioClip ñam;
    public AudioClip hueso;
    public AudioClip eructo;
    public AudioClip bolsa;
    public AudioClip barril;

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
            /*character.accelerationH = -collision.relativeVelocity.x;
            character.accelerationV = -collision.relativeVelocity.y;*/
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
                character.health--;
                character.oxygen -= ((character.oxygen / character.bottle) < character.health ? 0 
                    : (character.oxygen % character.bottle));
                if (character.health == 2)
                {
                    character.oxybottle3.gameObject.SetActive(false);
                }
                else if (character.health == 1)
                {
                    character.oxybottle2.gameObject.SetActive(false);
                }
                if (character.health <= 0)
                {
                    GenItems.generate = false;
                    Cursor.visible = true;
                    Destroy(GameObject.Find("Objects"));
                    character.finishInput = true;
                    character.submitRanking.SetActive(true);
                    character.theme.Stop();
                    character.gameover.Play();
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Point"))
        {
            puntuation.forward(collision);
            //AudioSource.PlayClipAtPoint(pointUp, this.transform.position);

            if (collision.gameObject.name == "pescado(Clone)" || collision.gameObject.name == "Manzana(Clone)")
            {
                AudioSource.PlayClipAtPoint(ñam, this.transform.position);
            }
            else if (collision.gameObject.name == "hueso(Clone)")
            {
                AudioSource.PlayClipAtPoint(hueso, this.transform.position);
            }
            else if (collision.gameObject.name == "Cola(Clone)")
            {
                AudioSource.PlayClipAtPoint(eructo, this.transform.position);
            }
            else if (collision.gameObject.name == "BolsaBasura(Clone)")
            {
                AudioSource.PlayClipAtPoint(bolsa, this.transform.position);
            }
            else if (collision.gameObject.name == "Barril(Clone)")
            {
                AudioSource.PlayClipAtPoint(barril, this.transform.position);
            }
        }
        else if (collision.gameObject.tag == "Oxygen")
        {
            Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(oxygen, this.transform.position);
            GenItems.items--;
            character.oxygen += 200;
            character.health++;
            if (character.health == 2)
            {
                character.oxybottle1.sprite = character.bottles[9];
                character.oxybottle2.gameObject.SetActive(true);
            }
            else if (character.health == 3)
            {
                character.oxybottle2.sprite = character.bottles[9];
                character.oxybottle3.gameObject.SetActive(true);
            }
            if (character.health > 3) character.health = 3;
            if (character.oxygen > 200 * character.health) character.oxygen = 200 * character.health;
        }
    }
}
