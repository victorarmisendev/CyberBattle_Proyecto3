using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Match : MonoBehaviour {

    public float totalTime;

    public static float event_timer = 10.0f;

    public Text winText;

    public float spawn_Objective;
    private float original_Spawn, O_event_timer;
    private bool win = false;
    public Text text;
    public GameObject objective;
    private List<GameObject> listOfObjectives;
    private bool begin = true;
    Vector3 randomPosition;
    public string event_method;
    public GameObject GameControl_Ev;
    public GameObject GameControl_Event_Pinchos, GameControl_Event_TheFloorIsLava, GameControl_Event_NightTime,
        GameControl_Event_Bomba;
    private float max = 0.0f;
    private string maxName = "";

    private void Start()
    {
        randomPosition = new Vector3();
        original_Spawn = spawn_Objective;
        O_event_timer = event_timer;

        InvokeRepeating("InstanceObjective", 3.0f, spawn_Objective);

        Debug.Log(event_method);

        EventRandom();

    }

    void Update ()
    {
        //Game Loop
        //Counters of the points
        //Check time
        //Set the time of the game

        totalTime -= Time.deltaTime;
        //text.text = totalTime.ToString();

        //Debug.Log(totalTime);

        if(totalTime <= 0)
        {
            //win = true;
            Debug.Log("Finish");
            totalTime = 0;
            GameObject [] players = GameObject.FindGameObjectsWithTag("Player");
            
            for (int i = 0; i < players.Length; i++)
            {
                if(players[i].GetComponent<Player>().points > max)
                {
                    max = players[i].GetComponent<Player>().points;
                    maxName = players[i].gameObject.name;
                }
            }

            winText.text = maxName;

            Finish();
        }

        //spawn_Objective -= Time.deltaTime;

        float size = Game_Grid.SIZEGLOBAL.x / 2;
        float sizeRandom = Random.Range(-size, size);
        float sizeRandomUp = Random.Range(1, size);

        randomPosition = new Vector3(sizeRandom, sizeRandomUp, sizeRandom);

        event_timer -= Time.deltaTime;

        if (event_timer <= 0)
        {
            EventRandom();
            Debug.Log("New event");
            event_timer = O_event_timer;
        }

        

    }

    void InstanceObjective()
    {
        Instantiate(objective, randomPosition, Quaternion.identity);
    }

    void Finish()
    {
        //We pass to another scene
        //Make a transition

        Time.timeScale = 0.0f;

    }

    void EventRandom()
    {
        GameObject event_map = new GameObject();
        event_map.transform.position = new Vector3(0, 0, 0);

        switch(event_method)
        {
            case "Moving":
                Debug.Log("Moving YEAH");
                GameObject[] objectives = GameObject.FindGameObjectsWithTag("Objective");
                for (int i = 0; i < objectives.Length; i++)
                {
                    objectives[i].gameObject.AddComponent<Moving_Objectives>();
                }            
                break;
            case "Spikes":
                Debug.Log("JumpSpike");
                Instantiate(GameControl_Event_Pinchos, transform.position, Quaternion.identity);                   
                break;
            case "Lava":
                Debug.Log("Lava");
                Instantiate(GameControl_Event_TheFloorIsLava, transform.position, GameControl_Event_TheFloorIsLava.transform.rotation);
                break;
            case "Night":               
                Instantiate(GameControl_Event_NightTime, transform.position, GameControl_Event_NightTime.transform.rotation);
                break;
            case "Bombs":
                Debug.Log("Bombs YEAH");


                for (int i = 0; i < 30; i++)
                {

                    float size = Game_Grid.SIZEGLOBAL.x / 2;
                    float sizeRandomX = Random.Range(-size, size);
                    float sizeRandomZ = Random.Range(-size, size);
                    float sizeRandomUp = Random.Range(1, size);

                    Vector3 randomPosition = new Vector3(sizeRandomX, sizeRandomUp, sizeRandomZ);

                    Instantiate(GameControl_Event_Bomba, randomPosition, Quaternion.identity);
                }


                break;
        }
        
    }


 

}
