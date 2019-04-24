using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Simple : MonoBehaviour {

    public GameObject particle, particle2;
    public GameObject weapon;
    public AudioSource shoot_Sound;
    public Camera camera_player;
    public Transform WeaponHolder;


    void Start ()
    {		
	}
	
	void Update ()
    {     
        ShootSimple();
    }

    void ShootSimple()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Debug.Log("SHOOT SIMPLE");

            RaycastHit hit;
            Ray ray = camera_player.ScreenPointToRay(Input.mousePosition);

            //Init particle Shooting

            Instantiate(particle2, WeaponHolder.transform.position, particle.transform.rotation);
            shoot_Sound.Play();

            if (Physics.Raycast(ray, out hit))
            {

                Instantiate(particle, hit.point, Quaternion.identity);
                

                Debug.Log("SHOOT SIMPLE");

                if (hit.collider.gameObject.tag == "Player")
                {
                    hit.collider.gameObject.GetComponent<Player_Stats>().live -= 10;
                    //Init particle hit

                    //Instantiate(particle, hit.point, Quaternion.identity);

                    if (hit.collider.gameObject.GetComponent<Player_Stats>().live <= 0)
                    {
                        gameObject.GetComponent<Player_Stats>().points += 1;
                    }
                }

                //Debug.DrawLine(transform.position, hit.point, Color.red);

            }

        }
    }



}
