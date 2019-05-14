using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Cam : MonoBehaviour {

    public float speedCam;
    public GameObject center;
	void Update () {
        transform.LookAt(center.transform.position);
        transform.Translate(Vector3.right * 0.00005f);

    }
}
