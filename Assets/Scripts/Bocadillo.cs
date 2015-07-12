using UnityEngine;
using System.Collections;

public class Bocadillo : MonoBehaviour
{

    private bool activo = false;
    public GameObject bocadillo;
    private float tiempo;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activo)
        {
            tiempo += Time.deltaTime;
            if (tiempo >= 5)
            {
                activo = false;
                bocadillo.SetActive(false);
            }
        }
    }

    public void activar()
    {
        bocadillo.SetActive(true);
        activo = true;
    }
}
