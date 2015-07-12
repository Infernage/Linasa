using UnityEngine;
using System.Collections;

public class CloseControl : MonoBehaviour
{
    public GameObject contenedor;
    public AudioSource toStop;
    public AudioSource toPlay;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

   public void OnClick()
    {
        contenedor.SetActive(false);
        if (toStop != null) toStop.Stop();
        if (toPlay != null) toPlay.Play();
    }
}
