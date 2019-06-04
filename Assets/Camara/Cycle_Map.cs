using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle_Map : MonoBehaviour {

    public GameObject[] points;
    private int counter = 0;
    public Camera cam;
    float timeCount2 = 0.0f; 
    private bool start = true;

	public Transform start_position;
    public Transform initial_rotation, final_rotation;

    private float timeCount = 0.0f;



    void Update ()
    {
    
        Game_Cycle(counter);

        if (start)
        {
            cam.transform.rotation = Quaternion.Slerp(initial_rotation.transform.rotation,
                final_rotation.transform.rotation, timeCount);

            timeCount = timeCount + Time.deltaTime * 0.6f;

            if (Vector3.Distance(cam.transform.position, points[0].transform.position) <= 0.1f)
            {
                start = false;
            }
        }

        if (Game_Manager.p.Length <= 1)
        {
            Destroy(this);
        }

        if(Vector3.Distance(cam.transform.position, points[counter].transform.position) <= 0.1f)
        {
            counter++;
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
