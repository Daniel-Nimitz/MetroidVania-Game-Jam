using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerBody;
    private Vector3 inputVector;
    public float speed = 5;
    public bool jump;
   
   
   

    // Start is called before the first frame update
    void Start()
    {
        //Just making sure we have the rigid body of the game object the script is attached to so we can move it later
        playerBody = gameObject.GetComponent<Rigidbody>();
       

    }

    // Update is called once per frame
    //This is where the player script should be realizing we are using inputs
    void Update()
    {
        //We find what input is coming into the computer from the WASD and/or Arrow Keys
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        //Our character will move based on WASD, here we get the input but it doesn't happen yet
        inputVector = new Vector3(horizontalInput * 10f, playerBody.velocity.y, verticalInput * 10f);
        transform.LookAt(new Vector3(inputVector.x, 0, inputVector.z));

        if (Input.GetButtonDown("Jump")){
            jump = true;
        }
    }
    //This is where the player should be implementing the inputs we put in
    private void FixedUpdate()
    {
        //this is where the computer actually makes the player moved off of the direstions we put into update
        playerBody.velocity = inputVector;
        //player jumps when on the ground and when they have not already used up their one jump
        if (jump && isGrounded())
        {
            playerBody.AddForce(Vector3.up * 10f, ForceMode.Impulse);
            jump = false;
        }
        //Player knows they are on the ground because a ray is drawn just under the player to sense if anything is there
        //This means that we can jump onto platforms as well as the ground easily
        bool isGrounded()
        {

            float distance = GetComponent<Collider>().bounds.extents.y + 1f;
            Ray ray = new Ray(transform.position, Vector3.down);
            return Physics.Raycast(ray, distance);
        }
    }
}
