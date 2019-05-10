using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_IT : MonoBehaviour {

	void Update ()
    {
        Destroy(this.gameObject, Game_Match.event_timer);
	}
}
