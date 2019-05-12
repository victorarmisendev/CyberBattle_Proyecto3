using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Plant : MonoBehaviour {

    private float timer = 4.0f;
    private bool aux = false;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(this);          
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Movement_Player>().speed_player = 10;

        }
        
    }

    void OnCollisionExit(Collision col)
    {
        col.gameObject.GetComponent<Movement_Player>().speed_player = 30;
    }



}
