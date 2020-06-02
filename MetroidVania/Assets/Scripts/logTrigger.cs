using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class logTrigger : MonoBehaviour
{
    public GameObject playerObject;
    PlayerMovement moveScript;
    public bool logTriggered;
    public float speedReduction;
    
    
   


    private void Start()
    {
        
        moveScript = playerObject.GetComponent<PlayerMovement>();
        
        
    }

    // Start is called before the first frame update
    void OnTriggerEnter (Collider other)
    {
        //the transform shrinks when it goes into the log
        playerObject.transform.localScale = new Vector3(1f, .8f, 1f);
        moveScript.speed -= speedReduction;
        logTriggered = true;
        
       
            

    }
    //Something is wrong with this part of the script
    private void OnTriggerExit(Collider other)
    {   //the transform grows when it leaves the log

        playerObject.transform.localScale = new Vector3(1f, 1f, 1f);
        moveScript.speed += speedReduction;
        logTriggered = false;
        
     
    }
    
}
