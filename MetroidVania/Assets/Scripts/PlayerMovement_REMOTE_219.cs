using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private Vector3 inputVector;
    [SerializeField]  private float speed = 5;
    [SerializeField] private bool jump;
    [SerializeField] private float turnSpeed = 45;
    [SerializeField] private float jumpForce = 10f;
    private int jumpCount = 0;
    



    // Start is called before the first frame update
    void Start()
    {
        //Just making sure we have the rigid body of the game object the script is attached to so we can move it later
        playerBody = gameObject.GetComponent<Rigidbody>();
        playerBody.AddForce(Vector3.up * jumpForce);

    }

    // Update is called once per frame
    //This is where the player script should be realizing we are using inputs
    void Update()
    {
        float horizantalInput = Input.GetAxis("Horizontal");
        float forwardInput = Input.GetAxis("Vertical");
        //We move the vehical forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //We turn the vehical
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizantalInput);

        if (Input.GetButtonDown("Jump") && jumpCount <= 2.0)
        {
            playerBody.AddForce(Vector3.up * jumpForce);
            print("Space has been pressed");
            jumpCount++;

        }
        //Need to add a statement for a bool if player is on ground reset jumpCount to 0.
    }
 
}
