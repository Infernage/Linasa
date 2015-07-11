using UnityEngine;
using System.Collections;

public class CloseControl : MonoBehaviour
{
    public GameObject contenedor;
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
    }
}
