using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Plant : MonoBehaviour {

    private float timer = 7.0f;
    private bool aux = false;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            aux = true;
            Destroy(this,0.1f);          
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //if(aux == true)
            //{
            //    collision.gameObject.GetComponent<Movement_Player>().PLAYER_IMMOVABLE = false;
            //} else
            //{
            //    collision.gameObject.GetComponent<Movement_Player>().PLAYER_IMMOVABLE = true;
            //}

            if(collision.gameObject.GetComponent<Movement_Player>().v_controller < 0)
            {
                collision.gameObject.transform.position += Vector3.up * 2.0f * Time.deltaTime;
            }
           
        }
        
    }


}
