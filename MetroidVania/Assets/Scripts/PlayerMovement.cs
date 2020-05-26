using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private Vector3 inputVector;
    [SerializeField] public float speed = 0.01f;
    [SerializeField] public bool jump;
    [SerializeField] private float turnSpeed = 45;
    [SerializeField] public float jumpForce = 10f;
    [SerializeField] private bool isOnGround;
    [SerializeField] private float playerHitPoints = 100;
    [SerializeField] float enemyPushForce = 100;
    public int ingredient;
    private int jumpCount = 0;
    public GameManager gameManager;
    public camSwitch cs;
    public float horizontalInput;
    public float verticalInput;
    float playerFacingAngleY;






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
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        playerFacingAngleY += horizontalInput * turnSpeed;
        Vector3 playerFacingDirection = new Vector3(0, playerFacingAngleY, 0);
        playerBody.rotation = Quaternion.Euler(playerFacingDirection);
        playerBody.AddRelativeForce(Vector3.forward * speed * verticalInput * Time.deltaTime);
        //playerBody.velocity = new Vector3(0, 0, speed * verticalInput * Time.deltaTime);
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
        else if (collision.gameObject.tag == "Ingredient")
        {

            Debug.Log("Player collided with an ingredient");
            collision.gameObject.SetActive(false);
            ingredient++;
        }

    }
}


