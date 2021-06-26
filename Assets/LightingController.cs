using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Shader.SetGlobalVector("_SunDirection", transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        // move directional light y angle based on angle of ball relative from x positon
    }
}
