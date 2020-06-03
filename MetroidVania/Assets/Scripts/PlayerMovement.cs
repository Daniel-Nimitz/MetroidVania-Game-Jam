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

    public GameManager gameManager;
    public camSwitch cs;
    public float horizontalInput;
    public float verticalInput;
    public float topSpeed = 10;
    public GameObject recipeUI; //related to recipe pick up

    private float playerFacingAngleY;
    private GameObject FocalPoint;
    private recipeManager recipeScript; //related to recipe pick up
    private bool canDoubleJump;
    private int jumpCount;
    


    // Start is called before the first frame update
    void Start()
    {
        //Just making sure we have the rigid body of the game object the script is attached to so we can move it later
        playerBody = gameObject.GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find("Focal Point");

        recipeScript = recipeUI.GetComponent<recipeManager>(); //allows recipe and ingrediennt pick up to inform the recipeManager
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


        //This is where we have our information about jumping
        //This is the first jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && jumpCount < 2)
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isOnGround = false;
            canDoubleJump = true;
            print("player has jumped");
        }
        //this adds the second jump, will need to add a condition for if they have the right pickup
        else if(Input.GetKeyDown(KeyCode.Space) && !isOnGround && canDoubleJump)
        {
           
                playerBody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
                canDoubleJump = false;
                print("player has double jumped");
        }




    }

   

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Player ran into an enemy");
            print("The Player has run into an enemy");
        }
       
        else if (collision.gameObject.tag == "Ground") {
            isOnGround = true;
            print("player has hit the ground");
        }

//picking up important game objects
        else if (collision.gameObject.name == "Recipe A") 
        {
            Debug.Log("Player collided with an recipe");
            collision.gameObject.SetActive(false);
            recipeScript.hasRecipe = true;
        }

        else if (collision.gameObject.name == "Essence Of Air ")
        {
            collision.gameObject.SetActive(false);
            recipeScript.Ingredients["Essence Of Air"] = true; 
        }

        else if (collision.gameObject.name == "Feather Of Placeholder")
        {
            collision.gameObject.SetActive(false);
            recipeScript.Ingredients["Feather of Placeholder"] = true;
        }

        else if (collision.gameObject.name == "Old Leaves Of The First Tree ")
        {
            collision.gameObject.SetActive(false);
            recipeScript.Ingredients["Old Leaves Of The First Tree"] = true;
        }

    }
}


