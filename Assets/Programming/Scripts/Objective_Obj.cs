using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective_Obj : MonoBehaviour
{
    public GameObject bandera;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && gameObject.tag == "Objective_Object")
        {
            Instantiate(bandera, Objective.PositionRandom(), this.gameObject.transform.rotation);
            collision.gameObject.GetComponent<Player>().points++;
            Destroy(gameObject);        
        }

    }

}
