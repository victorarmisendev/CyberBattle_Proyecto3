﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Player : MonoBehaviour {

    public Camera camera_player;
    public float speed_player, sprint_player, speed_rotation;
    private Quaternion initial_Rotation, I_Cam;
    private float originalSpeed;
    float mouseX, mouseY;
    public float jumpForce;
    public Animator anim;
    private Vector3 crouched, originalPosCamera;
    public bool PLAYER_IMMOVABLE = false;
    public bool CONTROLLER;
    private float Joy_Right_X = 0, Joy_Right_Y = 0;
    public float h_controller, v_controller;

    public string[] inputs;

    void Start ()
    {

        //inputs = new string[7];

        //transform.position += new Vector3(0, 5, 0);

        initial_Rotation = transform.localRotation;
        I_Cam = transform.localRotation;
        anim = GetComponent<Animator>();
        sprint_player = speed_player * 2;
        originalSpeed = speed_player;
        //crouched = camera_player.transform.position - new Vector3(0, 2, 0);
    }

    private void FixedUpdate()
    {
        Physics.gravity = new Vector3(0, -80, 0);
    }

    void Update ()
    {

        if(CONTROLLER)
        {
            //Make the movement with the controller here

            //Joy left:  Movement
            h_controller = Input.GetAxis(inputs[0]) * Time.deltaTime;
            v_controller = Input.GetAxis(inputs[1]) * Time.deltaTime;

            Joy_Right_X += Input.GetAxis(inputs[2]) * Time.deltaTime * speed_rotation;
            Joy_Right_Y += Input.GetAxis(inputs[3]) * Time.deltaTime * speed_rotation;

            //Joy_Right_Y = ClampAngle(Joy_Right_Y, -90, 90);
            //Joy_Right_X = ClampAngle(Joy_Right_X, -360, 360);

            Quaternion yAxis = Quaternion.AngleAxis(Joy_Right_X, Vector3.up);
            Quaternion xAxis = Quaternion.AngleAxis(Joy_Right_Y, Vector3.up);

            transform.localRotation = initial_Rotation /** yAxis*/ * yAxis;

            transform.localRotation =  xAxis;

            JumpPlayer(jumpForce);

            transform.Translate(h_controller * speed_player, 0, -v_controller * speed_player);

        }

        if(!CONTROLLER)
        {
            float h = Input.GetAxis("Horizontal") * Time.deltaTime;
            float v = Input.GetAxis("Vertical") * Time.deltaTime;

            if (PLAYER_IMMOVABLE)
            {
                h = 0.0f;
                v = 0.0f;
            }

            if (v > 0)
            {
                anim.Play("Walking");
            }
            else
            {
                anim.Play("Idle");
            }

            mouseX += Input.GetAxis("Mouse X");

            mouseY += Input.GetAxis("Mouse Y");

            transform.Translate(h * speed_player, 0, v * speed_player);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            mouseY = ClampAngle(mouseY, -90, 90);
            mouseX = ClampAngle(mouseX, -360, 360);

            Quaternion yAxis = Quaternion.AngleAxis(mouseX, Vector3.up);
            Quaternion xAxis = Quaternion.AngleAxis(-mouseY, Vector3.right);

            transform.localRotation = initial_Rotation /** yAxis*/ * yAxis;

            camera_player.transform.localRotation = I_Cam * xAxis;

            //camera_player.fieldOfView = 60;

            JumpPlayer(jumpForce);

            Sprint();

            Dash(25);

        }
        
        
        

        //Crouch();

        //originalPosCamera = transform.position;

        //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;

        //Debug.Log(Input.GetAxis("Mouse X"));

    }

    void JumpPlayer(float JumpForce)
    {
        if(CONTROLLER)
        {
            //Debug.Log(inputs[4]);
            if (Input.GetButton(inputs[4]))
                this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpForce, 0));
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpForce, 0));
        }
        
    }


    void Sprint()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed_player = sprint_player;
        } else
        {
            speed_player = originalSpeed;
        }
    }

    void Dash(float impulse)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * impulse, ForceMode.Impulse);
            //camera_player.fieldOfView = 90;
        } 


    }

    //void Crouch()
    //{
    //    if (Input.GetKeyDown(KeyCode.LeftControl))
    //        camera_player.transform.position = camera_player.transform.position - new Vector3(0, 2, 0); 
    //    else
    //        camera_player.transform.position = camera_player.transform.position + new Vector3(0, 2, 0);
    //}

    public static float ClampAngle(float angle, float min, float max)
    {
        angle = angle % 360;
        if ((angle >= -360F) && (angle <= 360F))
        {
            if (angle < -360F)
            {
                angle += 360F;
            }
            if (angle > 360F)
            {
                angle -= 360F;
            }
        }
        return Mathf.Clamp(angle, min, max);
    }


}
