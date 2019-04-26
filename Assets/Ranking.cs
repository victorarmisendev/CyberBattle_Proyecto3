using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour {

    public Text text;

	void Start ()
    {
        text.text = Game_Manager.name_winner;
    }
	

}
