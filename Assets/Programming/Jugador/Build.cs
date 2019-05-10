using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour {

    private float start_size;
    public GameObject prefab_reference;
    public Camera camera_player;

    private void Start()
    {
        start_size = prefab_reference.transform.localScale.y * 2;
        camera_player = gameObject.GetComponentInChildren<Camera>();
    }

    void Update ()
    {
        RaycastHit hit;
        Ray ray = new Ray();

        if (this.gameObject.name == "Player1")
            ray = camera_player.ScreenPointToRay(new Vector3((Screen.width / 2) / 2, Screen.height / 2, 1000));

        if (this.gameObject.name == "Player2")
            ray = camera_player.ScreenPointToRay(new Vector3((Screen.width / 2) + (Screen.width / 2) / 2, Screen.height / 2, 1000));

        if (Input.GetAxis(gameObject.GetComponent<Movement_Player>().inputs[5]) > 0)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.tag == "Soil")
                    ChangeBuild(hit.collider.gameObject, start_size);
            }
        }
     
	}
    
    private void ChangeBuild(GameObject obj, float startSize)
    {
        obj.transform.localScale = new Vector3(obj.transform.localScale.x, 
            obj.transform.localScale.y + startSize, obj.transform.localScale.z);
    }



}
