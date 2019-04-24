using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_1 : MonoBehaviour {

    bool active = false;
    float time = 0.0f;
    public Camera cam;

    public Motion Jump;
    public Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	void Update ()
    {
		if(active)
        {
            transform.position = Vector3.Slerp(transform.position, transform.position +
                transform.forward * 1 + Vector3.up * 1, time);
            time += Time.deltaTime * 0.04f;

            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(),
                GameObject.FindGameObjectWithTag("Platform_1").GetComponent<Collider>(), true);

            //if (time > 5.0f)
            //{
            //    Debug.Log("FINISH");

            //    time = 0.0f;
                
            //}

            //active = false;


        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("IN");
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("JUMP");
            //cam.transform.position -= Vector3.forward;
            anim.Play("Jump_01");
            anim.SetBool("Jump_01", true);
            anim.SetLayerWeight(0, 0);
            anim.SetLayerWeight(1, 100);
            //anim.SetBool("Idle", false);
            //anim.SetBool("Jump_01", true);
            //anim.SetBool("Walking", false);
            active = true;           
        }

        //Physics.IgnoreCollision(other.GetComponent<Collider>(), gameObject.GetComponent<Collider>(),true);
    }

    private void OnTriggerExit(Collider other)
    {
        active = false;
        //cam.transform.position += Vector3.forward;
        anim.Play("Idle");
        anim.SetBool("Jump_01",false);
        anim.SetLayerWeight(0, 100);
        anim.SetLayerWeight(1, 0);
        //Physics.IgnoreCollision(other.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), false);
        //Play Idle, now walk.
        //anim.Play("Idle");
        //anim.SetBool("Jump_01", f);
    }


}
