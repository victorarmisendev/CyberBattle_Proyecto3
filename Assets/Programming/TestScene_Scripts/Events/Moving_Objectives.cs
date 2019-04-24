using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Objectives : MonoBehaviour {

    Vector3[] directions;
    private float speed = 8.0f;
    private int dir = 1;
    private int rand;

    private void Start()
    {
        directions = new Vector3[2];
        directions[0] = Vector3.right;
        directions[1] = Vector3.forward;

        rand = Random.Range(0, directions.Length);

    }

    private void Update()
    {
        MoveDirection(directions[rand] * dir);

        //Debug.Log(dir);
    }


    void MoveDirection(Vector3 direction)
    {
        transform.Translate((((direction) * speed)) * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Untagged")
        {
            Debug.Log("COLLISION");
            dir = -dir;
        }

    }



}
