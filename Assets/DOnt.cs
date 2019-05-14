using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOnt : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
        DontDestroyOnLoad(this.gameObject);
	}
}
