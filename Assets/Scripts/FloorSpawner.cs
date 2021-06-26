using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{

    public List<GameObject> floors;
    private float offset = 900;
    // Start is called before the first frame update
    void Start()
    {
        if (floors != null && floors.Count > 0)
        {
            floors = floors.OrderBy(f => f.transform.position.z).ToList();
        }
    }

    public void MoveFloor()
    {
        GameObject movedFloor = floors[0];
        floors.Remove(movedFloor);
        float newZ = floors[floors.Count - 1].transform.position.z + offset;
        movedFloor.transform.position = new Vector3(0, 0, newZ);
        floors.Add(movedFloor);
    }
}
