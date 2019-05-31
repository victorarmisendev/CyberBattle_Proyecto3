using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle_Map : MonoBehaviour {

    public GameObject[] points;
    private int counter = 0;
    public Camera cam;
    float timeCount2 = 0.0f;
	
	void Update ()
    {

        //Debug.Log("Point 0: " + points[counter].transform.position);

        Game_Cycle(counter);
        
        if(Game_Manager.p.Length <= 1)
        {
            Destroy(this);
        }

        if(Vector3.Distance(cam.transform.position, points[counter].transform.position) <= 0.1f)
        {
            counter++;
            //Debug.Log(counter);
        }

        if(counter == points.Length)
        {
            counter = 0;
        }



	}

    void Game_Cycle(int counter)
    {
        float step = 45.0f * Time.deltaTime; // calculate distance to move    
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, points[counter].transform.position, step);      
    }
}
