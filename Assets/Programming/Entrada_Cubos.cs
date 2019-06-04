using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrada_Cubos : MonoBehaviour {

    private float step = 0.0f;

	void Update ()
    {


        transform.position = Vector3.Slerp(transform.position, transform.position - Vector3.up * Game_Grid.POS.y, step);
        step = step + Time.deltaTime; // calculate distance to move    


        //Destroy(this, 8.0f);

    }



}
