using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empuje : MonoBehaviour {

    BoxCollider[] boxColliders;

    public float forceImpulse;


    void Start ()
    {

        boxColliders = gameObject.GetComponents<BoxCollider>();

        boxColliders[0].enabled = true;
        boxColliders[1].enabled = false; //Collider Trigger

	}
	
	void Update ()
    {
		if(Input.GetButtonDown(this.GetComponent<Movement_Player>().inputs[6]))
        {
            boxColliders[1].enabled = true;
        }

        if(Input.GetButtonUp(this.GetComponent<Movement_Player>().inputs[6]))
        {
            boxColliders[1].enabled = false;
        }

	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Rigidbody>().AddForce(
                gameObject.transform.forward * forceImpulse, ForceMode.Impulse);
        }
    }



}
