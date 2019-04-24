using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour {

    public static GameObject[] objectives;
    public GameObject main_objective;
    public GameObject [] players;
    private bool win = false;
    public int objective_points;
    public GameObject text_template;
    private GameObject numberOfPlayers;
    public GameObject[] pointsOfPlayers;
    public Canvas parent;

	void Start ()
    {
        objectives = GameObject.FindGameObjectsWithTag("Objective");
        //main_objective.transform.position = PositionRandom();
        Vector3 position = PositionRandom();
        Instantiate(main_objective, position, main_objective.transform.rotation);
        //Debug.Log(position);
        players = GameObject.FindGameObjectsWithTag("Player");
        pointsOfPlayers = new GameObject[players.Length];
        SpawnText(players);
        numberOfPlayers = Instantiate(text_template, new Vector2(100, 625), text_template.transform.rotation); 
    }
	
	void Update ()
    {		
        //Check points of each player
        if(Win(players))
        {
            //Pasar a escena nueva de final de partida o..
            Application.Quit();
        }
        else
        {
            PlayersText(pointsOfPlayers, players);
            numberOfPlayers.GetComponent<Text>().text = "Number of players: " + players.Length.ToString();
            numberOfPlayers.transform.parent = parent.transform;
        }


	}

    public void SpawnText(GameObject[] players)
    {
        for (int i = 0; i < players.Length; i++)
        {
            pointsOfPlayers[i] = Instantiate(text_template, new Vector2(100 + i * 10, 100), 
                text_template.transform.rotation);
            pointsOfPlayers[i].transform.parent = parent.transform;
        }
    }

    public void PlayersText(GameObject [] textPoints, GameObject [] players)
    {
        for (int i = 0; i < players.Length; i++)
        {
            textPoints[i].GetComponent<Text>().text = "Points Player " + (i+1) + ": " + players[i].GetComponent
                <Player>().points.ToString();
        }
    }

    private bool Win(GameObject [] players)
    {
        bool result = false;
        for(int i = 0; i < players.Length; i++)
        {
            if(players[i].GetComponent<Player>().points + 1 == objective_points)
            {
                result = true;
                Debug.Log("Player " + (i + 1) + " Wins!!");
                return result;
            }
            else
            {
                result = false;
            }
        }
        return result;
    }

    public static Vector3 PositionRandom()
    {
        int RANDOM = Random.Range(0, objectives.Length-1);

        GameObject parent = objectives[RANDOM].gameObject;
        Vector3 objective_position = new Vector3();

        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject child = objectives[RANDOM].transform.GetChild(i).gameObject;

            if (child.tag == "Top_Tower")
            {
                objective_position = child.transform.position;

            }
        }

        return objective_position;

    }

}
