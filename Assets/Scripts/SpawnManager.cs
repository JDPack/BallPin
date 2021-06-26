using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    FloorSpawner floorSpawner;
    // Start is called before the first frame update
    void Start()
    {
        floorSpawner = GetComponent<FloorSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTriggerEntered()
    {
        floorSpawner.MoveFloor();
    }
}
