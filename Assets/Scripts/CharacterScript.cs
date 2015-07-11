﻿using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {
    public float max = 5;
    public float force = 0.01F;
    public float accelerationV = 0, accelerationH = 0;
    public float health = 3;
    public float oxygen = 600;
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

    public ParticleSystem particles;
    public GameObject sprite;
    public PuntuationManager puntuation;
    public bool subLife = true;

	// Use this for initialization
	void Start () {
	}

    private void loadRanking()
    {
        Application.LoadLevel("ranking");
    }
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float target = 0;
        if (v == -1)
        {
            target = 180;
            if (h == 1) target = 225;
            else if (h == -1) target = 135;
            if (accelerationV > 0 - max) accelerationV -= force * (accelerationV > 0 ? 2 : 1);
        }
        if (v == 1)
        {
            target = 0;
            if (h == 1) target = 315;
            else if (h == -1) target = 45;
            if (accelerationV < max) accelerationV += force * (accelerationV < 0 ? 2 : 1);
        }
        if (h == -1)
        {
            target = 90;
            if (v == 1) target = 45;
            else if (v == -1) target = 135;
            if (accelerationH > 0 - max) accelerationH -= force * (accelerationH > 0 ? 2 : 1);
        }
        if (h == 1 && accelerationH < max)
        {
            target = 270;
            if (v == 1) target = 315;
            else if (v == -1) target = 225;
            if (accelerationH < max) accelerationH += force * (accelerationH < 0 ? 2 : 1);
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
            particles.Play();

            Vector3 rotation = sprite.transform.rotation.eulerAngles;
            rotation.z = rotation.z % 360; // No more than 360 degrees
            float neededRotation = target - rotation.z;
            if (Mathf.Abs(neededRotation) < 1) // The rotation must be the target one if is close enough
            {
                neededRotation = 0;
            }
            else if (Mathf.Abs(neededRotation) >= 180)
            {
                neededRotation = (neededRotation < 0 ? 360 + neededRotation : -(360 - neededRotation)) * Time.deltaTime;
            }
            else
            {
                neededRotation *= Time.deltaTime;
            }
            sprite.transform.Rotate(Vector3.forward * neededRotation);
        }
        else
        {
            oxygen -= force;
            particles.Stop();
        }
        if (oxygen <= 0)
        {
            loadRanking();
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

    void LateUpdate()
    {
        Camera cam = Camera.main;
        Vector3 position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
        cam.transform.position = Vector3.Lerp(cam.transform.position, position, 3 * Time.deltaTime);
    }

    void FixedUpdate()
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
            if (subLife)
            {
                subLife = false;
                health--;
                if (health <= 0)
                {
                    loadRanking();
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
            oxygen += 200;
            if (oxygen > 600) oxygen = 600;
        }
    }
}
