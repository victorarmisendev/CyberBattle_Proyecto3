using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_Mode : MonoBehaviour {


    private GameObject suelo;
    public GameObject flag;

    void Start ()
    {

        GameObject[] paredes = GameObject.FindGameObjectsWithTag("Simulation");

        GameObject[,] cubos_suelo = new GameObject[0,0];
        GameObject initPath = new GameObject();

        int randomInits = Random.Range(3, 7); // Numero de caminos
        Debug.Log(randomInits);

        Vector3[] init_pathes = new Vector3[randomInits];

        for (int i = 0; i < paredes.Length; i++)
        {
            if (paredes[i].transform.eulerAngles == Vector3.zero)
            {
                cubos_suelo = paredes[i].GetComponent<Game_Grid>().cubos_matrix;
                Debug.Log(paredes[i].gameObject.name);
                Debug.Log(cubos_suelo[3,3].transform.eulerAngles);               
            }
        }

        int filasB = Random.Range(0, cubos_suelo.GetLength(0));
        int columnasB = Random.Range(0, cubos_suelo.GetLength(1));

        Instantiate(flag, cubos_suelo[filasB, columnasB].transform.position, Quaternion.identity);

        for (int i = 0; i < init_pathes.Length; i++)
        {
            //int filas = Random.Range(0, cubos_suelo.GetLength(0));
            //int columnas = Random.Range(0, cubos_suelo.GetLength(1));



            int filas = Random.Range(0, cubos_suelo.GetLength(0));
            int columnas = Random.Range(0, cubos_suelo.GetLength(1));
       
            //init_pathes[0] = cubos_suelo[filas, columnas].transform.position;

            cubos_suelo[filas, columnas].GetComponent<Renderer>().material.color = Color.blue;


            //init_pathes[i] = cubos_suelo[filas, columnas].transform.position;
            //cubos_suelo[filas, columnas].GetComponent<Renderer>().material.color = Color.blue;

            int counter = 0;

            while (!((filas == filasB) && (columnas == columnasB)))
            {
                int random1 = Random.Range(0, 10);
                int random2 = Random.Range(0, 10);
                int random3 = Random.Range(0, 10);
                //No ejecutar random3 más de una vez seguida

                if ((filasB - filas) > 0 && random1 > 5)
                {
                    filas++;
                }
                else if ((filasB - filas) < 0 && random1 > 5)
                {
                    filas--;
                }

                if ((columnasB - columnas) > 0 && random2 > 5)
                {
                    columnas++;
                }
                else if ((columnasB - columnas) < 0 && random2 > 5)
                {
                    columnas--;
                }

                if (((filas == filasB) && (columnas == columnasB)))
                {
                    break;
                }


                //path.Add(cubos_suelo[filas, columnas]);
                //path[counter].GetComponent<Renderer>().material.color = Color.magenta;

                //if(random3 > 7)
                //    cubos_suelo[filas, columnas].GetComponent<Renderer>().material.color = Color.yellow;
                if (random3 < 7)
                {
                    cubos_suelo[filas, columnas].GetComponent<Renderer>().material.color = Color.magenta;

                    //path[counter].transform.localScale = new Vector3(path[counter].transform.localScale.x,
                    //    3.0f * counter, path[counter].transform.localScale.z);

                    cubos_suelo[filas, columnas].transform.localScale = new Vector3(cubos_suelo[filas, columnas].transform.localScale.x,
                        3.0f * counter, cubos_suelo[filas, columnas].transform.localScale.z);

                    counter++;

                    //cubos_suelo[filas, columnas].GetComponent<Renderer>().material.color = Color.magenta;
                }
                //else
                //{
                //    cubos_suelo[filas, columnas].GetComponent<Renderer>().material.color = Color.yellow;
                //    counter++;
                //}


            }

        }




        //int filas = Random.Range(0, cubos_suelo.GetLength(0));
        //int columnas = Random.Range(0, cubos_suelo.GetLength(1));

        //int filasB = Random.Range(0, cubos_suelo.GetLength(0));
        //int columnasB = Random.Range(0, cubos_suelo.GetLength(1));

        //Instantiate(flag, cubos_suelo[filasB, columnasB].transform.position, Quaternion.identity);

        ////init_pathes[0] = cubos_suelo[filas, columnas].transform.position;

        //cubos_suelo[filas, columnas].GetComponent<Renderer>().material.color = Color.blue;

        //List<GameObject> path = new List<GameObject>();

        //path.Add(cubos_suelo[filas, columnas]);

        //int counter = 0;

        //while (!((filas == filasB) && (columnas == columnasB)))
        //{
        //    int random1 = Random.Range(0, 10);
        //    int random2 = Random.Range(0, 10);
        //    int random3 = Random.Range(0, 10);

        //    if ((filasB - filas) > 0 && random1 > 5)
        //    {
        //        filas++;
        //    }
        //    else if((filasB - filas) < 0 && random1 > 5)
        //    {
        //        filas--;
        //    }

        //    if ((columnasB - columnas) > 0 && random2 > 5)
        //    {
        //        columnas++;
        //    }
        //    else if((columnasB - columnas) < 0 && random2 > 5)
        //    {
        //        columnas--;
        //    }

        //    if(((filas == filasB) && (columnas == columnasB)))
        //    {
        //        break;
        //    }


        //    //path.Add(cubos_suelo[filas, columnas]);
        //    //path[counter].GetComponent<Renderer>().material.color = Color.magenta;

        //    if(random3 < 7)
        //    {
        //        cubos_suelo[filas, columnas].GetComponent<Renderer>().material.color = Color.magenta;

        //        //path[counter].transform.localScale = new Vector3(path[counter].transform.localScale.x,
        //        //    3.0f * counter, path[counter].transform.localScale.z);

        //        cubos_suelo[filas, columnas].transform.localScale = new Vector3(cubos_suelo[filas, columnas].transform.localScale.x,
        //            3.0f * counter, cubos_suelo[filas, columnas].transform.localScale.z);

        //        counter++;

        //        //cubos_suelo[filas, columnas].GetComponent<Renderer>().material.color = Color.magenta;
        //    }
        //    else
        //    {
        //        cubos_suelo[filas, columnas].GetComponent<Renderer>().material.color = Color.yellow;
        //        counter++;
        //    }


        //}

        //for (int i = 0; i < path.Capacity; i++)
        //{
        //    path[i].GetComponent<Renderer>().material.color = Color.magenta;
        //    path[i].transform.localScale += new Vector3(0,
        //        3.0f * i, 0);
        //    Debug.Log("HELLO");
        //}



    }

    void Update ()
    {
		
	}



}
