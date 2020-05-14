using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    public Rigidbody playerBody;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput =Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        Vector3 inputVector = new Vector3(horizontalInput * speed, playerBody.velocity.y, verticalInput * speed);
       
        //Will need a way to jump
    }
}
