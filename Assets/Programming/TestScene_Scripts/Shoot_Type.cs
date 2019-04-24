﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Type : MonoBehaviour {

    public GameObject GetGroup;
    //public GameObject particleVacio;
    //public GameObject particleFuego;

    public Camera camera_player;

    public enum type { Fuego, Vacio, Planta, Bounce};

    public type tipo;

    void Start ()
    {
        //tipo = type.Fuego;
	}
	
	void Update ()
    {
        //Debug.Log(tipo);


        switch (tipo)
        {
            case type.Fuego:
                Fire();
                break;
            case type.Vacio:
                Vacio();
                //Debug.Log("Enter");
                break;
            case type.Planta:
                Plant();
                break;
            case type.Bounce:
                Bounce();
                break;
        }
	}

    public void Vacio()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            Ray ray = camera_player.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Collider[] hitColliders = Physics.OverlapSphere(hit.collider.gameObject.transform.position, 10.0f);

                for (int i = 0; i < hitColliders.Length; i++)
                {
                    if (hit.collider.gameObject.transform.position != null && hitColliders[i].gameObject
                    .GetComponent<Renderer>() != null)
                    {                 
                        hitColliders[i].gameObject.GetComponent<Renderer>().material.color = Color.black;
                        hitColliders[i].gameObject.GetComponent<BoxCollider>().enabled = false;
                        //Instantiate(particleVacio, hitColliders[i].gameObject.transform.position, Quaternion.identity);

                    }
                }

            }
        }
        
        
    }

    public void Fire()
    {
        if (Input.GetButton(gameObject.GetComponent<Movement_Player>().inputs[6]))
        {
            RaycastHit hit;

            Ray ray = camera_player.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 50));
            //Not the size of the screen the size of the camera 

            if (Physics.Raycast(ray, out hit))
            {
                Collider[] hitColliders = Physics.OverlapSphere(hit.collider.gameObject.transform.position, 10.0f);

                for (int i = 0; i < hitColliders.Length; i++)
                {
                    if (hit.collider.gameObject.transform.position != null && hitColliders[i].gameObject
                    .GetComponent<Renderer>() != null)
                    {
                        hitColliders[i].gameObject.GetComponent<Renderer>().material.color = Color.red;
                        //EXTRA
                        hitColliders[i].gameObject.AddComponent<E_Fire>();

                        //Instantiate(particleFuego, hitColliders[i].gameObject.transform.position, Quaternion.identity);

                    }
                }

                //}

            }
        }
    }

    public void Plant()
    {
        if (Input.GetButton(gameObject.GetComponent<Movement_Player>().inputs[6]))
        {
            RaycastHit hit;

            Ray ray = camera_player.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 50));

            if (Physics.Raycast(ray, out hit))
            {
                Collider[] hitColliders = Physics.OverlapSphere(hit.collider.gameObject.transform.position, 10.0f);

                for (int i = 0; i < hitColliders.Length; i++)
                {
                    if (hit.collider.gameObject.transform.position != null && hitColliders[i].gameObject
                    .GetComponent<Renderer>() != null)
                    {
                        hitColliders[i].gameObject.GetComponent<Renderer>().material.color = Color.green;

                        //EXTRA
                        hitColliders[i].gameObject.AddComponent<E_Plant>();

                    }
                }

                //}

            }
        }
    }

    public void Bounce()
    {
        if (Input.GetButton(gameObject.GetComponent<Movement_Player>().inputs[6]))
        {
            RaycastHit hit;

            Ray ray = camera_player.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 50));

            if (Physics.Raycast(ray, out hit))
            {
                Collider[] hitColliders = Physics.OverlapSphere(hit.collider.gameObject.transform.position, 5.0f);

                for (int i = 0; i < hitColliders.Length; i++)
                {
                    if (hit.collider.gameObject.transform.position != null && hitColliders[i].gameObject
                    .GetComponent<Renderer>() != null)
                    {
                        hitColliders[i].gameObject.GetComponent<Renderer>().material.color = Color.magenta;

                        //EXTRA
                        hitColliders[i].gameObject.AddComponent<Bounce>();

                    }
                }

                //}

            }
        }
    }


}
