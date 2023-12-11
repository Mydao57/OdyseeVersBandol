using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateWagons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject wagons;
    public Transform[] waypoints;
    public Grid train;
    void Start()
    {
        GenerateWagon();
    }

    private void GenerateWagon()
    {
        foreach (Transform waypoint in waypoints)
        {
            GameObject wagon = Instantiate(wagons, waypoint.position, waypoint.rotation);
            wagon.transform.parent = train.transform;
        }
    }
}
