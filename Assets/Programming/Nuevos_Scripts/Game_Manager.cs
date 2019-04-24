using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour {


    public string[] inputs_player1;
    public string[] inputs_player2;

    private float timer = 3.0f;

    public static List<GameObject> Grid_Cube = new List<GameObject>();

    public GameObject[] players;

    private void Start()
    {

        inputs_player1 = new string[7];
        inputs_player2 = new string[7];

        inputs_player1[0] = "JoyX_P1";
        inputs_player1[1] = "JoyY_P1";

        inputs_player1[2] = "JoyX_Right_P1";
        inputs_player1[3] = "JoyY_Right_P1";

        inputs_player1[4] = "A_P1";
        inputs_player1[5] = "RT_P1";
        inputs_player1[6] = "B_P1";

        /////////////////

        inputs_player2[0] = "JoyX_P2";
        inputs_player2[1] = "JoyY_P2";

        inputs_player2[2] = "JoyX_Right_P2";
        inputs_player2[3] = "JoyY_Right_P2";

        inputs_player2[4] = "A_P2";
        inputs_player2[5] = "RT_P2";
        inputs_player2[6] = "B_P2";

        players[0].GetComponent<Movement_Player>().inputs = inputs_player1;
        players[1].GetComponent<Movement_Player>().inputs = inputs_player2;



    }

    private void LateUpdate()
    {
        timer -= Time.deltaTime;

        if(timer < 0.0f)
        {
            for (int i = 0; i < 30; i++)
            {
                int ran_num = Random.Range(0, Game_Manager.Grid_Cube.Capacity);
                if(Game_Manager.Grid_Cube[ran_num] != null)
                {
                    Game_Manager.Grid_Cube[ran_num].GetComponent<Renderer>().material.color = Color.red;
                    Game_Manager.Grid_Cube[ran_num].AddComponent<Rigidbody>();
                    Game_Manager.Grid_Cube[ran_num].GetComponent<Rigidbody>().AddForce(Vector3.forward * 5.0f, ForceMode.Impulse);
                }            
            }
            timer = 3.0f;
        } 

    }


}
