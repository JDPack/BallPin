using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed.SetText("Player Vel: " + player.GetComponent<Rigidbody>().velocity.ToString());
    }
}
