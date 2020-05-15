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
        float horizantalInput = Input.GetAxis("Horizontal");
        float forwardInput = Input.GetAxis("Vertical");
        //We move the vehical forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //We turn the vehical
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizantalInput);






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
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
