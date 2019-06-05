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

    public int ROUNDS;
    private int actual_Rounds = 0;

    public GameObject[] fortificaciones;

    private bool final_Stage = false;

    public Transform centerPoint;

    public GameObject [] other_Stages;

    private bool Add_Caida = false;

    public GameObject bandera;



    void Update ()
    {
        if(!final_Stage)
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
                actual_Rounds++;
                Debug.Log("Numero de vueltas: " + actual_Rounds);
            }
        }
        

        if(actual_Rounds >= ROUNDS)
        {

            bandera.gameObject.SetActive(true);

            final_Stage = true;

            for (int i = 0; i < fortificaciones.Length; i++)
            {
                Destroy(fortificaciones[i].gameObject);
            }

            float step2 = 25.0f * Time.deltaTime; // calculate distance to move    
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, centerPoint.position, step2);

            //if(Add_Caida == false)
            //{
            //    for (int i = 0; i < other_Stages.Length; i++)
            //    {
            //        for (int j = 0; j < other_Stages[i].transform.childCount; j++)
            //        {
            //            other_Stages[i].transform.GetChild(j).gameObject.AddComponent<Rigidbody>();
            //            Destroy(other_Stages[i].gameObject, 10.0f);
            //        }
                
            //    }
            //    Add_Caida = true;
            //}

            //Probar mas tarde
            //if(Add_Caida == false)
            //{
            //for (int i = 0; i < other_Stages.Length; i++)
            //{
            //    for (int j = 0; j < Random.Range(1,3); j++)
            //    {
            //        int random = Random.Range(1, other_Stages[j].transform.childCount);

            //        if (other_Stages[i].transform.GetChild(random).gameObject != null && )
            //        {
            //           other_Stages[i].transform.GetChild(random).gameObject.AddComponent<Rigidbody>();
            //           Destroy(other_Stages[i].gameObject, 10.0f);
            //        }                                  
            //    }


            //}
            //Add_Caida = true;
            //}

            //camera_Follow?? 

            //Hacemos el stageFinal
        }


        //counter == 0, actual_Rounds++;
        /*
         * 
        if(actual_rounds >= ROUNDS) {
            Attack_FinalStage();
            for(...) {
                Grid_Cube[i].AddComponent<Rigidbody>();
                Destroy(Grid_Cube[i], 10.0f);
                //Se cae sobre el suelo
                //Todos estos efectos de particulas codigo en el soil.
                //Si es roca: Particles (OnCollisionEnter)
                //Si es agua: Particles (OnCollisionEnter)
                //Si es futurista: No particles
                //Si es jungle: Particles hojas (OnCollisionEnter)               
            }

        Destruir portones y esquinas para entrada.
        //Ronda final(?) Caida de los cubos al cabo del tiempo linea a linea.
        //Instanciar bandera  o dejar instanciada? 
        //If bandera pick -> Se acabo la partida cambio de pantalla y +5000 puntos al jugador.

        }

        void Attack_FinalStage(Type attack) {

            switch(attack) 
            {
                case "Base": // Cubos caen asecas por las fisicas.
                    break;
                case "Volcano": 
                //De dentro del volcan, hacemos lo siguiente:
                //Instanciamos bolas de fuego o lava en el punto dentro del volcan o fuera de el justo al lado.
                //Le aplicamos las siguiente fuerzas en direccion a las 8 plataformas que se van a destruir y destruimos 
                //la mayoria de cubos en un rango de la bola. (TriggerEnter = Destroy Soil o gameObject)
                //Los cubos restantes se les dara Rigidbody para que caigan por su propio pie.
                    break;
                case "Barco": 
                //La misma funcionalidad que el volcan pero son cañones.
                //Se disparan balas de cañon y destruyen de la misma manera el suelo determinado.
                //Fisicas y cae todo al agua. 
                //Hacerlo flotar: DIFICIL.
                case "Jungle": 


                case "Futurista": 
                //Laser(?)

            }

        }


        */



    }

    void Game_Cycle(int counter)
    {
        float step = 185.0f * Time.deltaTime; // calculate distance to move    
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, points[counter].transform.position, step);  
        
        

    }
}
