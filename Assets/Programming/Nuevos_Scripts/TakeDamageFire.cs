using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageFire : MonoBehaviour {


    //O le ponemos un trigger a todos
    //O ponemos una rutina que cuando colisione
    //le haga daño durante unos segundos 
    //Pero si queremos que coja daño mientras este dentro 
    //Seria util utilizar un trigger

    private void Update()
    {
        Destroy(this.gameObject
            , 5.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<P_Properties>().live -= 1;
        }
    }


}
