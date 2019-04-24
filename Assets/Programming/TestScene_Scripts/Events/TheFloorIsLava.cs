using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFloorIsLava : MonoBehaviour {

    private float timeCount = 0.0f;
    private float timeCount2 = 0.0f;
    private float timerGlobal = 0.0f;

    void Start ()
    {
        transform.localScale += new Vector3(Game_Grid.SIZEGLOBAL.x/2, 0, Game_Grid.SIZEGLOBAL.y/2);
        transform.position += new Vector3(0, 1, 0);

        timerGlobal = Game_Match.event_timer;

    }

    //Code physics

    void Update ()
    {

        transform.position = Vector3.Slerp(transform.position, transform.position + new Vector3(0, 2, 0), timeCount);
        timeCount = timeCount * Time.deltaTime * 0.005f;

        timerGlobal -= Time.deltaTime;

        if (timerGlobal <= 0.0f)
        {
            transform.position = Vector3.Slerp(transform.position, transform.position - new Vector3(0, 2, 0), timeCount2);
            timeCount2 = timeCount2 * Time.deltaTime * 0.005f;

            Destroy(this.gameObject);
        }


    }
}
