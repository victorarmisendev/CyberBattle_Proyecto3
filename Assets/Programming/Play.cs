using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour {

    AudioSource audio;

	// Use this for initialization
	void Start () {
        this.audio = GetComponent<AudioSource>();
        this.audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
