using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPoint : MonoBehaviour {

    //Make a function that check if the player killed the other player

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player_Stats>().points += 5;
            Destroy(this.gameObject);
        }
    }

}
