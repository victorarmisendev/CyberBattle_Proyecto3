using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Stats : MonoBehaviour {

    public float points;
    //Objectives gives 5 points 
    //Kills give 1 point
    public float live;
    public int numberOfLives;
    float timer = 5.0f;
    //public Transform position_extern;


    void Start()
    {
        points = 0;
        live = 100;
    }

    private void Update()
    {
        Die();

        //HasMuerto();

        live = Mathf.Clamp(live, 0, 100);

        //Points();

        //If player lives are equal to 0, lose the game, destroy player.
        if (numberOfLives == 0)
        {
            Destroy(this.gameObject);
        }

    }


    public void GetDamage(float damage)
    {
        live -= damage;
    }

    void Points()
    {

        //if(!dead)
        //this.points += Time.deltaTime; 
                                
    }

    void Die()
    {
        if(this.live <= 0)
        {
            //Fuking dead m8
            //Debug.Log("Die");
            numberOfLives--;
            this.live = 100;
        }
    }

    //void HasMuerto()
    //{
    //    if (dead)
    //    {
    //        timer -= Time.deltaTime;

    //        transform.position = position_extern.position;


    //        if (timer <= 0)
    //        {

    //            //dead = true;
    //            Die_Direct();
    //            //Aqui viene el respawn controlado
    //            //transform.position = Vector3.zero + Vector3.up * 1.0f;
    //            GameObject[] soils = GameObject.FindGameObjectsWithTag("Soil");
    //            List<GameObject> white_soils = new List<GameObject>();
    //            for (int i = 0; i < soils.Length; i++)
    //            {
    //                if (soils[i].GetComponent<Renderer>().material.color == Color.white)
    //                {
    //                    white_soils.Add(soils[i]);
    //                }
    //            }
    //            GameObject random = white_soils[Random.Range(0, white_soils.Capacity)];
    //            Vector3 offset = new Vector3(0, 4, 0);
    //            transform.position = random.transform.position + offset;


    //            dead = false;

    //        }


    //    }



    //}


    void Die_Direct()
    {
        numberOfLives--;
        this.live = 100;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Bandera")
        {
            points += 5000;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                //MIRAR LOADSCENE ASINCRON PARA CARGAR LA PANTALLA
                //DE PUNTUACION SIN TENER QUE PASAR LOS VALORES A LA SIGUIENTE ESCENA
                //AUNQUE LO PODEMOS HACER POR ESTATICOS PERFECTAMENTE

        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Dead_Space")
        {
            this.Die_Direct();
            //Aqui viene el respawn controlado
            //transform.position = Vector3.zero + Vector3.up * 1.0f;
            GameObject[] soils = GameObject.FindGameObjectsWithTag("Soil");
            List<GameObject> white_soils = new List<GameObject>();
            for (int i = 0; i < soils.Length; i++)
            {
                if (soils[i].GetComponent<Renderer>().material.color == Color.white)
                {
                    white_soils.Add(soils[i]);
                }
            }
            //GameObject random = white_soils[Random.Range(0, white_soils.Capacity)];
            Vector3 random = new Vector3(Random.Range(-140, 140), 8, Random.Range(-140, 140));
            Vector3 offset = new Vector3(0, 2, 0);
            transform.position = random + offset;
            

        }
    }





}
