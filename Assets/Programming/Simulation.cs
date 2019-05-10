using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour {


	void Start ()
    {
        //Screen.
        //Screen.SetResolution(800, 800, true);


        GameObject[] simulations = GameObject.FindGameObjectsWithTag("Simulation");

        //simulations[1].transform.Translate(0, 0, -Game_Grid.SIZEGLOBAL.x / 2);
        //simulations[1].transform.Rotate(90, 0, 0);
        

        //simulations[2].transform.Translate(-Game_Grid.SIZEGLOBAL.x / 2, 0, 0);
        //simulations[2].transform.Rotate(90, 90, 0);
       

        simulations[3].transform.Translate(0, 0, Game_Grid.SIZEGLOBAL.x / 2);
        simulations[3].transform.Rotate(90, 0, 0);
        

        simulations[4].transform.Translate(Game_Grid.SIZEGLOBAL.x / 2, 0, 0);
        simulations[4].transform.Rotate(90, 90, 0);

  

        for (int i = 1; i < simulations.Length; i++)
        {
            int children = simulations[i].gameObject.transform.childCount;

            for (int j = 0; j < children; j++)
            {
                simulations[i].gameObject.transform.GetChild(j).GetComponent<Renderer>().material.color = Color.white;
                //Debug.Log("Color");
            }
           
        }

    }
	

	void Update ()
    {
		
	}
}
