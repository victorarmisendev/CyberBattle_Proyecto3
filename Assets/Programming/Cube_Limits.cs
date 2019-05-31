using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Limits : MonoBehaviour {


    public List<GameObject> cubes_respawn;

    void Update()
    {
        for (int i = 0; i < cubes_respawn.Capacity; i++)
        {
            if(cubes_respawn[i] == null)
            {
                cubes_respawn.Remove(cubes_respawn[i]);
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Soil" /*&& *//*!cubes_respawn.Contains(col.gameObject)*/)
        {
            cubes_respawn.Add(col.gameObject);
            col.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }

        if (col.gameObject.tag == "Player")
        {
            Debug.Log(col.name + "Estoy dentro!");
        }
    }



    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            //    //Perderemos una puntuacion
            //    //-100;
            //    col.gameObject.GetComponent<Player_Stats>().points -= 100;

            //    Vector3 offset = new Vector3(0, 2, 0);
            //    Vector3 random = cubes_respawn[Random.Range(0, cubes_respawn.Capacity - 1)].transform.position;
            //    //Reset y respawn en uno de los cubos visibles por la camara
            //    col.gameObject.transform.position = random + offset;

            //    Debug.Log(col.name + "He salido!");
        }
      

        if (col.gameObject.tag == "Soil")
        {
            //col.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }

    }




}
