using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEffects : MonoBehaviour {

    public GameObject particle_shoot;

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

        if(col.gameObject.tag == "Bullet")
        {      
            Instantiate(particle_shoot, col.transform.position, Quaternion.identity);           
        }

    }

}
