using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private float Force_ = -30.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Not bad, we need to improve it
            collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.contacts[0].normal * Force_, ForceMode.Impulse);        
        }
    }


    void OnCollisionExit(Collision col)
    {
        col.gameObject.GetComponent<Movement_Player>().speed_player = 30;
    }




}
