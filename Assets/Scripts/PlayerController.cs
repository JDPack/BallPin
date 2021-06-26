using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpawnManager spawnManager;

    public float zMoveSpeed = 200f;
    private float speedBoost = 0f;

    public float xMoveSpeed = 200f;
    public int maxLane = 2;
    public int minLane = -2;
    private int targetLane = 0;

    private bool canMove = false;

    private Rigidbody rb;
    private float xInput;
    private float zInput;

    private Vector3 moveToTarget = Vector3.zero;
    private float lastSqrMag = Mathf.Infinity;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //rb.velocity = Vector3.forward * 200;
        //moveToTarget = Vector3.forward * getZMoveSpeed();
    }

    private void Update()
    {
        ProcessInputs();
    }

    // Physics-based movement
    private void FixedUpdate()
    {

        Move();

    }

    private void ProcessInputs()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        //Debug.Log("xinput is " + xInput);
        if (!canMove)
        {
            if (xInput < 0 && targetLane > minLane)
            {
               // Debug.Log("move here");
                targetLane--;
                // get directional vector to target
                moveToTarget = new Vector3(-xMoveSpeed, moveToTarget.y, moveToTarget.z);
                lastSqrMag = Mathf.Infinity;
                canMove = true;
            }
            else if (xInput > 0 && targetLane < maxLane)
            {
                targetLane++;
                // get directional vector to target
                moveToTarget = new Vector3(xMoveSpeed, moveToTarget.y, moveToTarget.z);
                lastSqrMag = Mathf.Infinity;
                canMove = true;
            }
        }


    }

    private void Move()
    {
        if (canMove)
        {

            float nextXPosition = rb.position.x + (moveToTarget.x * Time.deltaTime);
            Debug.Log("moving to " + nextXPosition);

            float sqrMag = (new Vector3(targetLane * 50f, rb.position.y, rb.position.z) - new Vector3(nextXPosition, rb.position.y, rb.position.z)).sqrMagnitude;

            if (sqrMag > lastSqrMag)
            {
                Debug.Log("target achieved " + rb.position.x);
                rb.position = new Vector3(targetLane * 50f, rb.position.y, rb.position.z);
                canMove = false;
                moveToTarget = Vector3.zero;
            }
            lastSqrMag = sqrMag;
        }

        rb.velocity = getZMove() + moveToTarget;

    }

    public Vector3 getZMove()
    {
        return Vector3.forward * (zMoveSpeed + speedBoost);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpawnTrigger")
        {
            spawnManager.SpawnTriggerEntered();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Flipper")
        {
            //restart, turn off motion, etc
            //Debug.Log("here we are");
            //Vector3 direction = collision.GetContact(0).normal;
            //rb.velocity = direction * 200f;
        }
        if (collision.gameObject.tag == "SpeedBoost") {
            Debug.Log("speedboost");
            speedBoost += 50f;
        }

    }
}
