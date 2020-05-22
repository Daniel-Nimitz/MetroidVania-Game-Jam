using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class logTrigger : MonoBehaviour
{
    public BoxCollider bc;
    public CapsuleCollider cc;
    public GameObject playerObject;
    PlayerMovement moveScript;
    public bool logTriggered;
   


    private void Start()
    {
        
        moveScript = playerObject.GetComponent<PlayerMovement>();
        
    }

    // Start is called before the first frame update
    void OnTriggerEnter (Collider other)
    {
        if (Input.GetKey("c"))
        {
            //the box and capsule collider both shrink in size and the speed slows down.
            bc.size = new Vector3(1f, 1f, 1f);
            bc.center = new Vector3(5.960464e-08f, -0.5f, -8.940697e-08f);
            cc.height = 1f;
            moveScript.speed = 2f;
            logTriggered = true;
        }
            

    }
    private void OnTriggerExit(Collider other)
    {   //the box and capsule collider both grow in size and the speed returns to normal.
        bc.size = new Vector3(1f, 2f, 1f);
        bc.center = new Vector3(5.960464e-08f, 0f, -8.940697e-08f);
        cc.height = 2f;
        moveScript.speed = 10f;
        logTriggered = false;
     
    }

}
