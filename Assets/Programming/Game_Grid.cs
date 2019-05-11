using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Grid : MonoBehaviour {

    public GameObject soil;
    public GameObject gameMap;
    public Vector2 size;
    public float nodeRadius;
    private float NodeDiameter;
    public LayerMask unwalkable;
    public Vector3 mainRotation;
    public static Vector2 SIZEGLOBAL;
    public static float NODEDIAM;
    public string notfloor;
    //private int rows, columns;
    //public Vector2 size;
    //public float nodeDiameter,nodeDIAM;
    public GameObject jump_it;
    public GameObject column;

    public List<GameObject> cubos = new List<GameObject>();
    public GameObject[,] cubos_matrix;

    public bool FlagTime, DieMode;

    void Start ()
    {
        //Vector3 bounds = gameMap.transform.localScale;
        //nodeDIAM = nodeDiameter * 2;
        //int SizeX = Mathf.RoundToInt(size.x / (nodeDIAM));
        //int SizeZ = Mathf.RoundToInt(size.y / (nodeDIAM));

        SIZEGLOBAL = size;
        
        //Vector3 esquina = transform.position - Vector3.right * (bounds.x / 2) - Vector3.forward * (bounds.z / 2);
        NodeDiameter = nodeRadius * 2;

        NODEDIAM = NodeDiameter;

        soil.transform.localScale = new Vector3(NodeDiameter, 1, NodeDiameter);

        Vector3 esquina = transform.position - Vector3.right * (size.x / 2) - Vector3.forward * (size.y / 2);
        Vector3 correction = new Vector3(nodeRadius, 0, nodeRadius);

        //Instantiate(soil, esquina + correction, Quaternion.identity);
        //Instantiate(soil, esquina + correction + new Vector3(0,0,NodeDiameter * 1.1f), Quaternion.identity);

        int rows = Mathf.RoundToInt(size.x / NodeDiameter);
        int columns = Mathf.RoundToInt(size.y / NodeDiameter);

        cubos_matrix = new GameObject[rows, columns];

        //Debug.Log(rows);
        //Debug.Log(columns);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Vector3 POS = (esquina + correction) + new Vector3(i * NodeDiameter * 1.005f, 0,
                    j * NodeDiameter * 1.005f);
                GameObject cube = Instantiate(soil, POS, Quaternion.identity) as GameObject;
                
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

        if(!FlagTime && !DieMode)
        {
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("Soil");

            for (int i = 0; i < cubes.Length; i++)
            {
                int ran1 = Random.Range(0, 5);
                int ran2 = Random.Range(0, 5);

                if (ran1 == ran2)
                {
                    if (ran1 < 3)
                        Instantiate(jump_it, cubes[i].transform.position + new Vector3(0, 3, 0), Quaternion.identity);
                    if (ran1 > 3)
                        Instantiate(column, cubes[i].transform.position + new Vector3(0, 8, 0), Quaternion.identity);
                }

            }
        }

        


    }

}
