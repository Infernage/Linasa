using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PuntuationManager : MonoBehaviour {
    public int puntuationNumber = 0;
    private Text puntuation;

	// Use this for initialization
	void Start () {
        puntuation = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void forward(Collider2D collider)
    {
        string[] split = collider.gameObject.tag.Split(new char[] { ' ' });
        int point = System.Convert.ToInt32(split[0]);
        puntuationNumber += point;
        puntuation.text = "Puntuación: " + puntuationNumber;
        Destroy(collider.gameObject);
        GenItems.items--;
    }
}
