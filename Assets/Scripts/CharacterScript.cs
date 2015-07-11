using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {
    public float max = 10;
    public float force = 1;
    public float accelerationV = 0, accelerationH = 0;
    public float oxygen = 600;
    private AudioSource acelTop;
    private AudioSource acelBot;
    private AudioSource acelRight;
    private AudioSource acelLeft;
    private bool acelerarArriba = false;
    private bool acelerarAbajo = false;
    private bool acelerarDerecha = false;
    private bool acelerarIzq = false;

    #region Propiedades
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
    #endregion Propiedades

    public ParticleSystem particles;
    public GameObject sprite;

    // Use this for initialization
    void Start()
    {
        AudioSource[] audios = this.gameObject.GetComponents<AudioSource>();
        foreach (AudioSource source in audios)
        {
            Cursor.visible = false;
            if (source.clip.name == "Aire a presión")
            {
                acelTop = source;
                acelBot = source;
            }
            else if (source.clip.name == "Aire a presión derecha")
            {
                acelRight = source;
            }
            else if (source.clip.name == "Aire a presión izqu")
            {
                acelLeft = source;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel("menu");
            return;
        }
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float target = 0;
        if (v == -1)
        {
            if (!acelerarArriba)
            {
                acelTop.Play();
            }
            target = 180;
            if (h == 1) target = 225;
            else if (h == -1) target = 135;
            if (accelerationV > 0 - max) accelerationV -= force * (accelerationV > 0 ? 2 : 1);
            acelerarArriba = true;
        }
        else
        {
            if (acelerarArriba)
            {
                acelerarArriba = false;
                acelTop.Pause();
            }
        }
        if (v == 1)
        {
            if (!acelerarAbajo)
            {
                acelBot.Play();
            }
            target = 0;
            if (h == 1) target = 315;
            else if (h == -1) target = 45;
            if (accelerationV < max) accelerationV += force * (accelerationV < 0 ? 2 : 1);
            acelerarAbajo = true;
        }
        else
        {
            if (acelerarAbajo)
            {
                acelBot.Pause();
                acelerarAbajo = false;
            }
        }
        if (h == -1)
        {
            if (!acelerarDerecha)
            {
                acelRight.Play();
            }
            target = 90;
            if (v == 1) target = 45;
            else if (v == -1) target = 135;
            if (accelerationH > 0 - max) accelerationH -= force * (accelerationH > 0 ? 2 : 1);
            acelerarDerecha = true;
        }
        else
        {
            if (acelerarDerecha)
            {
                acelerarDerecha = false;
                acelRight.Pause();
            }
        }
        if (h == 1 && accelerationH < max)
        {
            if (!acelerarIzq)
            {
                acelLeft.Play();
            }
            target = 270;
            if (v == 1) target = 315;
            else if (v == -1) target = 225;
            if (accelerationH < max) accelerationH += force * (accelerationH < 0 ? 2 : 1);
            acelerarIzq = true;
        }
        else
        {
            if (acelerarIzq)
            {
                acelLeft.Pause();
                acelerarIzq = false;
            }
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
            oxygen -= 0.1F;
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
            oxygen -= 0.01F;
            acelBot.Pause();
            acelTop.Pause();
            acelLeft.Pause();
            acelRight.Pause();
            acelerarIzq = false;
            acelerarDerecha = false;
            acelerarAbajo = false;
            acelerarArriba = false;
            particles.Stop();
        }
        if (oxygen <= 0)
        {
            Cursor.visible = true;
            Application.LoadLevel("ranking");
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


}
