using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private Vector3 inputVector;
    [SerializeField] public float speed = 0.01f;
    [SerializeField] public bool jump;
    [SerializeField] private float turnSpeed = 45;
    [SerializeField] public float jumpForce = 35000f;
    [SerializeField] private bool isOnGround = true;
    [SerializeField] float enemyPushForce = 100;
    public int ingredient;
    public GameManager gameManager;
    public camSwitch cs;
    public float horizontalInput;
    public float verticalInput;
    float playerFacingAngleY;
    private GameObject FocalPoint;
    public float topSpeed = 10;
   

    // Start is called before the first frame update
    void Start()
    {
        //Just making sure we have the rigid body of the game object the script is attached to so we can move it later
        playerBody = gameObject.GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find("Focal Point");
    }
    void FixedUpdate() //using rigidbody? => ONLY FIXEDUPDATE
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        playerFacingAngleY += horizontalInput * turnSpeed;
        Vector3 playerFacingDirection = new Vector3(0, playerFacingAngleY, 0);
        playerBody.rotation = Quaternion.Euler(playerFacingDirection);
        float moveDirectionX = (FocalPoint.transform.position.x - gameObject.transform.position.x) * speed * verticalInput * Time.deltaTime;
        float moveDirectionZ = (FocalPoint.transform.position.z - gameObject.transform.position.z) * speed * verticalInput * Time.deltaTime;
        Vector3 moveDirection = new Vector3(moveDirectionX, 0.0f, moveDirectionZ); //0.0f - just turn on gravity in rigidbody component or you can change it if you want some additional Vertical force
        playerBody.AddForce(moveDirection, ForceMode.VelocityChange); //force mode change to whatever you want 
        if (playerBody.velocity.magnitude > topSpeed)
            playerBody.velocity = playerBody.velocity.normalized * topSpeed;
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isOnGround = false;
            print("player has jumped");
        }
    }

    // Update is called once per frame
    //This is where the player script should be realizing we are using inputs
    //void Update()
    //{
    //horizontalInput = Input.GetAxis("Horizontal");
    // verticalInput = Input.GetAxis("Vertical");
    // playerFacingAngleY += horizontalInput * turnSpeed;
    // Vector3 playerFacingDirection = new Vector3(0, playerFacingAngleY, 0);
    //  playerBody.rotation = Quaternion.Euler(playerFacingDirection);
    // float moveDirectionX = (FocalPoint.transform.position.x - gameObject.transform.position.x) *speed * verticalInput * Time.deltaTime;
    //  float MoveDirectionY = jumpForce * Physics.gravity.y;
    // float moveDirectionZ = (FocalPoint.transform.position.z - gameObject.transform.position.z) * speed * verticalInput * Time.deltaTime;
    //  Vector3 moveDirection = new Vector3(moveDirectionX, MoveDirectionY, moveDirectionZ);



    //    playerBody.velocity = moveDirection;

    //  if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
    //  {
    //      playerBody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    //      isOnGround = false;
    //      print("player has jumped");
    //  }

    // }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Player ran into an enemy");
            if (cs.inSky == true)
            {
                speed = 0;
            }
            else
            {
                speed = 10;
            }
        }
        else if (collision.gameObject.tag == "Ingredient")
        {

            Debug.Log("Player collided with an ingredient");
            collision.gameObject.SetActive(false);
            ingredient++;
        }
        else if (collision.gameObject.tag == "Ground") {
            isOnGround = true;
            print("player has hit the ground");
        }

    }
}


