using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Grid : MonoBehaviour {

    public GameObject soil;
    public GameObject gameMap;
    public GameObject jump_it;
    public GameObject column;
    public GameObject[,] cubos_matrix;
    public float[,] alturas_a_restar;
    public List<GameObject> cubos = new List<GameObject>();

    public Vector3 mainRotation;
    public Vector2 size;
    public static Vector2 SIZEGLOBAL;

    public float nodeRadius;
    private float NodeDiameter;
    public static float NODEDIAM;

    public LayerMask unwalkable;

    public string notfloor;
    public bool FlagTime, DieMode;

    public static Vector3 POS;

    void Start ()
    {

        SIZEGLOBAL = size;
        
        NodeDiameter = nodeRadius * 2;
        NODEDIAM = NodeDiameter;

        soil.transform.localScale = new Vector3(NodeDiameter, 10, NodeDiameter);

        Vector3 esquina = transform.position - Vector3.right * (size.x / 2) - Vector3.forward * (size.y / 2);
        Vector3 correction = new Vector3(nodeRadius, 0, nodeRadius);

        int rows = Mathf.RoundToInt(size.x / NodeDiameter);
        int columns = Mathf.RoundToInt(size.y / NodeDiameter);

        cubos_matrix = new GameObject[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                POS = (esquina + correction) + new Vector3(i * NodeDiameter * 1.02f, 0,
                    j * NodeDiameter * 1.02f);

                float altura_inicial = Random.Range(100, 200);

                GameObject cube = Instantiate(soil, POS + Vector3.up * altura_inicial, Quaternion.identity) as GameObject;

                //alturas_a_restar[i, j] = altura_inicial;
                cube.AddComponent<Entrada_Cubos>();

                cube.gameObject.tag = "Soil";
                cube.transform.parent = gameObject.transform;

                if (Physics.CheckSphere(POS, nodeRadius, unwalkable))
                {
                    cube.GetComponent<Renderer>().material.color = Color.blue;
                }

                Game_Manager.Grid_Cube.Add(cube);
                cubos.Add(cube);

                cubos_matrix[i, j] = cube;


            }
        }

        /*   
        gameObject.transform.Translate(Vector3.up * -1);

        Building grid

        if(!FlagTime && !DieMode)
        {
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("Soil");

            for (int i = 0; i < cubes.Length; i++)
            {
                int ran1 = Random.Range(0, 10);
                int ran2 = Random.Range(0, 10);

                if (ran1 == ran2)
                {
                    if (ran1 < 3)
                        Instantiate(jump_it, cubes[i].transform.position + new Vector3(0, 3, 0), jump_it.transform.rotation);
                    if (ran1 > 3)
                        Instantiate(column, cubes[i].transform.position + new Vector3(0, 8, 0), column.transform.rotation);
                }

            }
        }
        */


    }

}
