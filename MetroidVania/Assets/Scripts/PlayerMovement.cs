using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private Vector3 inputVector;
    [SerializeField]  private float speed = 5;
    [SerializeField] private bool jump;
    [SerializeField] private float turnSpeed = 45;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private bool isOnGround;
    [SerializeField] private float playerHitPoints = 100;
    [SerializeField] float enemyPushForce = 100;
    public int ingredient;
    private int jumpCount = 0;
    public GameManager gameManager;
    public camSwitch cs;





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

        if (Input.GetButtonDown("Jump") && jumpCount <= 2.0 && isOnGround)
        {
            playerBody.AddForce(Vector3.up * jumpForce);
            print("Space has been pressed");
            jumpCount++;
            isOnGround = false;
        }
        if (playerHitPoints <= 0) {
            gameManager.GameOver();
        }

        
        //Need to add a statement for a bool if player is on ground reset jumpCount to 0.
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Player ran into an enemy");
            playerHitPoints -= 30;
            playerBody.AddForce((collision.gameObject.transform.position - transform.position) * enemyPushForce, ForceMode.Impulse);
            if (cs.inSky == true)
            {
                speed = 0;
            }
            else
            {
                speed = 10;
            }
        }
        if (collision.gameObject.tag == "Ingredient") {
            Debug.Log("player picked up an ingredient");
            collision.gameObject.SetActive(false);
            ingredient++;
        }
        
        
    }
       
        
}
