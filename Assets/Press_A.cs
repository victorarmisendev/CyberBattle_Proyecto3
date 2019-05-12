using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Press_A : MonoBehaviour {

	
    void Update()
    {
        if(Input.GetButtonDown("A_P1") || Input.GetButtonDown("A_P1"))
        {
            SceneManager.LoadScene(1);
        }
    }

}
