using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pincho_Daño : MonoBehaviour {

    public float damage;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1));
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player_Stats>().GetDamage(damage);
        }
    }

}
