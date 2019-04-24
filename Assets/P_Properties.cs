using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Properties : MonoBehaviour {

    public int live;
    public int energy;

    public void TakeDamage()
    {
        live -= 10;
    }

}
