using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class logTrigger : MonoBehaviour
{
    public GameObject playerObject;
    public bool logTriggered;
    public float speedReduction;

    private PlayerMovement moveScript;

//for player animations ================
//======================================
    public GameObject animationObject;
    Animator anim;

    private void Start()
    {
        
        moveScript = playerObject.GetComponent<PlayerMovement>();

        anim = animationObject.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void OnTriggerEnter (Collider other)
    {
        //the transform shrinks when it goes into the log
        playerObject.transform.localScale = new Vector3(1f, .7f, 1f);
        moveScript.topSpeed -= speedReduction;
        logTriggered = true;

        //makes the player crouch
        anim.SetBool("crouchAnimation", true);

        
       
            

    }
    //Something is wrong with this part of the script
    private void OnTriggerExit(Collider other)
    {   //the transform grows when it leaves the log

        playerObject.transform.localScale = new Vector3(1f, 1f, 1f);
        moveScript.topSpeed += speedReduction;
        logTriggered = false;

        //makes the player stop crouching
        anim.SetBool("crouchAnimation", false);
    }
    
}
