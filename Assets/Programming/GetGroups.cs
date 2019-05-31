using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGroups : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.AddComponent<VacioCom>();
    }

}
