using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private GameObject focalPoint;
    public Rigidbody playerRb;
    public float speed;
    public float rotationSpeed;
    public float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Propellor");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate

        playerRb.AddForce(focalPoint.transform.forward * speed * 1);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.left * rotationSpeed * verticalInput);
    }
}
