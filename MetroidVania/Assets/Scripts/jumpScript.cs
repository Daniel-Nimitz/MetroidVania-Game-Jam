
using UnityEngine;

public class jumpScript : MonoBehaviour
{
    public float fallMultiple = 2.5f;
    Rigidbody playerPhys;
    public float jumpForce = 520f;
    [SerializeField] private bool grounded;
    public CapsuleCollider col;
    public LayerMask groundLayers;
    public float heightOffset = 1.0f;
    public float groundedHeight = 1.0f;


    void Start()
    {
        playerPhys = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        InvokeRepeating("GroundCheck", 0, 0.1f);
    }

    // The jump action
    void Update()
    {
        if (grounded == true && Input.GetKeyDown(KeyCode.Space))
            playerPhys.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        
    }

    //Function to check if the player is grounded.
    void GroundCheck()
    {
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + heightOffset, transform.position.z), Vector3.down, groundedHeight + heightOffset, groundLayers))
            grounded = true;
        else
            grounded = false;
    }
}
