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
        string[] split = puntuation.text.Split(new char[] { ' ' });
        int current = System.Convert.ToInt32(split[1]);
        if (current != puntuationNumber)
        {
            current = puntuationNumber;
        }
        puntuation.text = "Puntuación: " + current;
	}

    public void forward(Collider2D collider)
    {
        string[] split = collider.gameObject.tag.Split(new char[] { ' ' });
        int point = System.Convert.ToInt32(split[0]);
        puntuationNumber += point;
        Destroy(collider.gameObject);
        GenItems.items--;
    }
}
