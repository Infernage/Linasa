using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PuntuationManager : MonoBehaviour {
    public int puntuationNumber = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Text puntuation = GetComponent<Text>();
        string str = puntuation.text;
        int current = System.Convert.ToInt32(str.Split(new char[]{ ' ' })[1]);
        if (current != puntuationNumber)
        {
            current = puntuationNumber;
        }
        puntuation.text = "Puntuación: " + current;
	}

    public void forward(Collision collider)
    {
        int point = System.Convert.ToInt32(collider.gameObject.tag.Split(new char[] { ' ' }[0]));
        puntuationNumber += point;
    }
}
