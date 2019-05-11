using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacioCom : MonoBehaviour {

    void Start ()
    {
        gameObject.GetComponent<Collider>().enabled = false;
	}
	

}
