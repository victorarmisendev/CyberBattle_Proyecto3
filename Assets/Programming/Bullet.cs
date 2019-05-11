using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    void Start()
    {
        StartCoroutine(init(0.5f));
    }

    IEnumerator init(float s)
    {

        GetComponent<SphereCollider>().enabled = false;

        yield return new WaitForSeconds(s);

        GetComponent<SphereCollider>().enabled = true;

    }


}
