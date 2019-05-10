using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightTime : MonoBehaviour {

    public int numberOfFarolas;
    public GameObject farola_Prefab;
    private float timer = 0.0f;
    private GameObject mainLight;


    void Start ()
    {
        timer = Game_Match.event_timer;

        mainLight = GameObject.FindGameObjectWithTag("MainLight");

        for (int i = 0; i < numberOfFarolas; i++)
        {

            float size = Game_Grid.SIZEGLOBAL.x / 2;
            float sizeRandomX = Random.Range(-size, size);
            float sizeRandomZ = Random.Range(-size, size);
            float sizeRandomUp = Random.Range(1, size);

            Vector3 randomPosition = new Vector3(sizeRandomX, sizeRandomUp, sizeRandomZ);

            Instantiate(farola_Prefab, randomPosition, Quaternion.identity);
        }

        mainLight.GetComponent<Light>().intensity = 0;
        RenderSettings.ambientIntensity = 0;

    }
	
	void Update ()
    {

        timer -= Time.deltaTime;

		if(timer <= 0.0f)
        {
            mainLight.GetComponent<Light>().intensity = 1;
            RenderSettings.ambientIntensity = 1;
            Destroy(this.gameObject);        
        }
	}
}
