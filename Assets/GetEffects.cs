using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEffects : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Fuego" && gameObject.tag == "Soil")
        {
            gameObject.AddComponent<E_Fire>();
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }

        if (col.gameObject.tag == "Planta" && gameObject.tag == "Soil")
        {
          
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            gameObject.AddComponent<E_Plant>();
        }

        if (col.gameObject.tag == "Bote" && gameObject.tag == "Soil")
        {
            gameObject.AddComponent<Bounce>();
            gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        }

        if (col.gameObject.tag == "Vacio" && gameObject.tag == "Soil")
        {
            gameObject.AddComponent<VacioCom>();
            gameObject.GetComponent<Renderer>().material.color = Color.black;
        }

    }

}
