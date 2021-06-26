using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject sunReflection;

    private Vector3 offsetCamera;
    private Vector3 offsetReflection;
    // Start is called before the first frame update
    void Start()
    {
        offsetCamera = transform.position - player.transform.position;
        offsetReflection = sunReflection.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(-player.transform.position.x, offsetCamera.y, offsetCamera.z);
        sunReflection.transform.position = player.transform.position + new Vector3(-player.transform.position.x, offsetReflection.y, offsetReflection.z);
    }
}
