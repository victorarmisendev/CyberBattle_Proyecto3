using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour {

    public int points;
    //Objectives gives 5 points 
    //Kills give 1 point
    public float live;

    void Start()
    {
        points = 0;
        live = 100;
    }

    private void Update()
    {
        Die();

        live = Mathf.Clamp(live, 0, 100);

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
        }
    }


}
