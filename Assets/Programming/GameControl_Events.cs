using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl_Events : MonoBehaviour {

    public GameObject screen;
    public Material materialBomb;
    public Material moving;
    public Material materialSpikes;
    public Material lava;
    public Material night;

    //public static float timer = 10.0f;
    private float OriginalTimer;

    public struct States
    {
        public string name_method;
        public Material mat;
    }

    States [] state = new States[5];

    void Start ()
    {
        //OriginalTimer = timer;

        state[0].mat = moving;
        state[0].name_method = "Moving";
        state[1].mat = materialSpikes;
        state[1].name_method = "Spikes";
        state[2].mat = lava;
        state[2].name_method = "Lava";
        state[3].mat = night;
        state[3].name_method = "Night";
        state[4].mat = materialBomb;
        state[4].name_method = "Bombs";

        int RAN = Random.Range(0, 5);

        int NUMBER = RAN;

        Debug.Log(NUMBER);

        screen.GetComponent<Renderer>().material = state[NUMBER].mat;

        GameObject obj = GameObject.FindGameObjectWithTag("GameControl");
        obj.GetComponent<Game_Match>().event_method = state[NUMBER].name_method;

    }
	
	void Update ()
    {
        //timer -= Time.deltaTime;

        //Debug.Log(Game_Match.event_timer);

        bool prove = Game_Match.event_timer <= 1;
        Debug.Log(prove);
        if (prove)
        {
            //Get Random Sprite image and print it to the screen
            //Pass the value to the game control

            //Debug.Log(RAN);

            int RAN = Random.Range(0, 5);
            int NUMBER = RAN;

            Debug.Log(NUMBER);

            Debug.Log(NUMBER);

            screen.GetComponent<Renderer>().material = state[NUMBER].mat;
            //Pass the number to game control... state[i].number;

            GameObject obj = GameObject.FindGameObjectWithTag("GameControl");
            obj.GetComponent<Game_Match>().event_method = state[NUMBER].name_method;

            //timer = OriginalTimer;

        }

    }
}
