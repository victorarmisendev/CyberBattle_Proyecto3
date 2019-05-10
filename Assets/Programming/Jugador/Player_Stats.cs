using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour {

    public int points;
    //Objectives gives 5 points 
    //Kills give 1 point
    public float live;
    public int numberOfLives = 3;

    void Start()
    {
        points = 0;
        live = 100;
    }

    private void Update()
    {
        Die();

        live = Mathf.Clamp(live, 0, 100);

        //If player lives are equal to 0, lose the game, destroy player.
        if(numberOfLives == 0)
        {
            Destroy(this.gameObject);
        }

    }


    public void GetDamage(float damage)
    {
        live -= damage;
    }

    void Die()
    {
        if(this.live <= 0)
        {
            //Fuking dead m8
            Debug.Log("Die");
            numberOfLives--;
        }
    }

    void Die_Direct()
    {
        numberOfLives--;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Dead_Space")
        {
            this.Die_Direct();
            transform.position = Vector3.zero + Vector3.up * 1.0f;
        }
    }




}
