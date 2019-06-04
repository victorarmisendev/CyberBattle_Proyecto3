using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrada_Cubos : MonoBehaviour {

    private float step = 0.0f;
    private GameObject startPos;
    private Transform initial_Pos;

    void Start()
    {
        startPos = GameObject.FindGameObjectWithTag("StartPos_Cubos");
        initial_Pos = transform;
    }

	void Update ()
    {

        //float step = 3.0f * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(initial_Pos.position.x, startPos.transform.position.y,
        //    initial_Pos.position.z), step);

  



        //Destroy(this, 7.0f);

    }



}
