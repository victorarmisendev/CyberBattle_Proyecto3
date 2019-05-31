using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour {
		
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject.tag != "GetGroups")
                {
                    //hit.collider.enabled = false;
                    hit.collider.gameObject.transform.localScale = new Vector3(Game_Grid.NODEDIAM, 7, Game_Grid.NODEDIAM);
                    hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.cyan;
                }
            }
        }
	}
}
