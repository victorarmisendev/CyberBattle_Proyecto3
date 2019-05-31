using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour {

    public string[] inputs_player1;
    public string[] inputs_player2;
    public Text text;
    public Text live_p1, live_p2;
    private int counter = 0;
    public static string name_winner;

    private float timerBegin = 1.0f;
    private float timer = 3.0f;

    public string[] begin_text = new string[4];

    private bool gameBegins = false;

    public static List<GameObject> Grid_Cube = new List<GameObject>();

    public int numero_falls;

    public GameObject[] players;

    public bool FlagTime_Mode;

    public GameObject flag, particles_tierra, particles_seguir;

    public Text points1, points2;

    public static GameObject[] p = new GameObject[2]; // Ahora lo ponemos de dos, seran 4 jugadores.

    private void Start()
    {

        //if (FlagTime_Mode)
        //{
        //    //Instantiate(flag, Vector3.zero, Quaternion.identity);
        //    //Get walls
        //    GameObject[] soils = GameObject.FindGameObjectsWithTag("Soil");
        //    List<GameObject> walls = new List<GameObject>();

        //    //for (int i = 0; i < soils.Length; i++)
        //    //{
        //    //    if (soils[i].transform.eulerAngles != Vector3.zero)
        //    //    {
        //    //        walls.Add(soils[i]);
        //    //        Debug.Log("HELLLLOOOO");
        //    //    }

        //    //}
        //    Vector3 flagPosition = new Vector3();
        //    flagPosition = soils[Random.Range(0, soils.Length - 1)].transform.position;
        //    Debug.Log(flagPosition + "Hello");
        //    Instantiate(flag, flagPosition, Quaternion.identity);
        //}

        name_winner = "";

        begin_text[0] = "3";
        begin_text[1] = "2";
        begin_text[2] = "1";
        begin_text[3] = "Fight!";

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

    private void Update()
    {

        GameObject[] p = GameObject.FindGameObjectsWithTag("Player");
        //Debug.Log(p.Length);
        if(players[0] != null)
        {
            //points1.text = "Points: " + players[0].GetComponent<Player_Stats>().points.ToString();
            live_p1.text = "Player1 Lives: " + players[0].GetComponent<Player_Stats>().numberOfLives.ToString();
        }
            
        if(players[1] != null)
        {
            //points2.text = "Points: " + players[1].GetComponent<Player_Stats>().points.ToString();
            live_p2.text = "Player2 Lives: " + players[1].GetComponent<Player_Stats>().numberOfLives.ToString();
        }
            

        if (counter < 4)
        {
            timerBegin -= Time.deltaTime;
            if (timerBegin > 0.0f)
            {
                text.text = begin_text[counter];                
            }
            else
            {
                counter++;
                timerBegin = 1.0f;
            }
        }
        else
        {
            gameBegins = true;
            text.text = "";
        }
      
        if (gameBegins)
        {
            timer -= Time.deltaTime;

            if(FlagTime_Mode == false)
            {
                if (timer < 0.0f)
                {
                    for (int i = 0; i < numero_falls; i++)
                    {
                        int ran_num = Random.Range(0, Game_Manager.Grid_Cube.Capacity);

                        if (Game_Manager.Grid_Cube[ran_num] != null)
                        {
                            //Explosion: No loop
                            GameObject particle = Instantiate(particles_tierra, Game_Manager.Grid_Cube[ran_num].transform.position, Quaternion.identity);
                            particle.transform.SetParent(Game_Manager.Grid_Cube[ran_num].transform);
                            particle.transform.localScale = new Vector3(10, 10, 10);
                            //Humo: Loop
                            GameObject particle2 = Instantiate(particles_seguir, Game_Manager.Grid_Cube[ran_num].transform.position, Quaternion.identity);
                            particle2.transform.SetParent(Game_Manager.Grid_Cube[ran_num].transform);
                            particle2.transform.localScale = new Vector3(3, 3, 3);

                            Destroy(particle, 5.0f);
                            Destroy(particle2, 7.0f);

                            Game_Manager.Grid_Cube[ran_num].GetComponent<Renderer>().material.color = Color.yellow;

                            Game_Manager.Grid_Cube[ran_num].AddComponent<Rigidbody>();
                            //Game_Manager.Grid_Cube[ran_num].GetComponent<Rigidbody>().AddForce(Vector3.forward * 50.0f, ForceMode.Impulse);
                            //Game_Manager.Grid_Cube[ran_num].GetComponent<Rigidbody>().AddForce(Vector3.right * 5.0f, ForceMode.Impulse);



                            Destroy(Game_Manager.Grid_Cube[ran_num], Random.Range(1.0f, 7.0f));
                        }
                    }
                    timer = 3.0f;
                }
            }

            

            

            if(p.Length == 1)
            {
                Debug.Log(p[0].name);
                //Finish the match
                //Go the ranking scene
                //Go to the winner scene
                name_winner = p[0].name;
                p[0].GetComponent<Player_Stats>().points += 1000.0f;
                SceneManager.LoadScene(5);

            }
            
                
            


        }

 
    }

}
