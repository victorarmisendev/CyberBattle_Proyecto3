using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTime : MonoBehaviour {

    private GameObject[] surfaces;
    public GameObject prefab_Pincho;
    public Material materialPincho;
    public GameObject particleSpike;

    void Start ()
    {
       surfaces = GameObject.FindGameObjectsWithTag("Simulation");

       Spike_Time();
    }

    private void Update()
    {
        Destroy(this.gameObject, Game_Match.event_timer);
    }

    void Spike_Time()
    {
        for (int i = 0; i < surfaces.Length; i++)
        {
            int children = surfaces[i].gameObject.transform.childCount;

            for (int j = 0; j < children; j++)
            {
                int Ran1 = Random.Range(0, 25);
                int Ran2 = Random.Range(0, 25);

                if(surfaces[i].transform.rotation.x == 0.0f)
                {
                    if (Ran1 == Ran2)
                    {
                        Vector3 positionSpike = surfaces[i].gameObject.transform.GetChild(j).transform.
                        position + new Vector3(0, 2, 0);
                        Instantiate(particleSpike, positionSpike, Quaternion.identity);
                        GameObject obj = Instantiate(prefab_Pincho, positionSpike, prefab_Pincho.transform.rotation);
                        obj.transform.localScale += new Vector3(0.10f, 0.10f, 0.10f);
                        obj.GetComponent<Renderer>().material = materialPincho;
                    }
                }
                
                            
            }
        }
    }

}
