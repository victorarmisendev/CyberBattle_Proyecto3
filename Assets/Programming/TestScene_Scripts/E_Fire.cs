using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Fire : MonoBehaviour {

    private float timer = 7.0f;
	
	void Update ()
    {

        timer -= Time.deltaTime;
        /*
        if (Physics.CheckSphere(gameObject.transform.position, 5.0f))
        {

        }
        ^*/
        
        if (timer <= 0)
        {

            Destroy(this);

        }


    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player_Stats>().GetDamage(0.15f);
        }
            //collision.gameObject.GetComponent<Player_Type>().GetDamageFire();
    }



}
