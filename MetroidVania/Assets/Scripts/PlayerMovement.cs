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
    private bool canDoubleJump = false;
    public bool doubleJumpUnlocked; //used by recipeManager scrip
    public bool bugVisionUnlocked = false; //used by camSwitch script
    private int jumpCount;

    //for tutorial message
    GameObject tutorialObject;
    tutorialManager tutorialScript;

//for the recipeManger==================
//======================================
    public bool gotAir;
    public bool gotFeather;
    public bool gotLeaf;

//for player animations ================
//======================================
    public GameObject animationObject;
    Animator anim;

    //for pillbug animations===============
    //=====================================
    public GameObject bugFriend;
    Animator buganim;

//music =====================
    audioManager audioScript;
    GameObject audioObject;
    




    // Start is called before the first frame update
    void Start()
    {
        //music
        audioObject = GameObject.Find("AudioManager");
        audioScript = audioObject.GetComponent<audioManager>();

        //Just making sure we have the rigid body of the game object the script is attached to so we can move it later
        playerBody = gameObject.GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find("Focal Point");

        recipeScript = recipeUI.GetComponent<recipeManager>(); //allows recipe and ingrediennt pick up to inform the recipeManager

        //fills boxes for tutorial message
        tutorialObject = GameObject.Find("Tutorial UI");
        tutorialScript = tutorialObject.GetComponent<tutorialManager>();

        anim = animationObject.GetComponent<Animator>();

        buganim = bugFriend.GetComponent<Animator>();

 
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
            //makes the player jump up
            anim.SetBool("jumpAnimation", true);
        }
        //this adds the second jump, will need to add a condition for if they have the right pickup
        else if(Input.GetKeyDown(KeyCode.Space) && !isOnGround && canDoubleJump == true && doubleJumpUnlocked == true)
        {
           
                playerBody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
                canDoubleJump = false;
                print("player has double jumped");
        }

//makes the running animation happen=================================================
//===================================================================================
        if(Input.GetKeyDown("w"))
        {
            anim.SetBool("runAnimation", true);
        }
        else if(Input.GetKeyUp("w"))
        {
            anim.SetBool("runAnimation", false);
        }

        if (Input.GetKeyDown("s"))
        {
            anim.SetBool("runBackwardsAnimation", true);
        }

        else if(Input.GetKeyUp("s"))
        {
            anim.SetBool("runBackwardsAnimation", false);
        }


    }

   

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
          
        if(collision.gameObject.tag == "Ground") {
            isOnGround = true;
            //makes the player land after jumping
            anim.SetBool("jumpAnimation", false);
        }

//picking up important game objects
        else if (collision.gameObject.name == "Recipe A") 
        {
           
            collision.gameObject.SetActive(false);
            recipeScript.hasRecipe = true;

            //recipe tutorial
            tutorialScript.startrecipe();

            audioScript.Chimes();
        }

        else if (collision.gameObject.name == "Essence Of Air ")
        {
        
            collision.gameObject.SetActive(false);
            gotAir = true;
            audioScript.Chimes();
        }

        else if (collision.gameObject.name == "Feather Of Placeholder")
        {
            collision.gameObject.SetActive(false);
            gotFeather = true;

            audioScript.Chimes();
        }

        else if (collision.gameObject.name == "Old Leaves Of The First Tree ")
        {
            collision.gameObject.SetActive(false);
            gotLeaf = true;

            audioScript.Chimes();
        }

        else if (collision.gameObject.name == "Bug")
        {
            collision.gameObject.SetActive(false);
            bugVisionUnlocked = true;

            //opens tutioral message
            tutorialScript.startBug();

            bugFriend.SetActive(true);

            audioScript.Reward();




        }
    }
}


