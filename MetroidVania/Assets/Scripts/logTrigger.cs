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
    public float speedReduction;
    Vector3 boxSizeChange = new Vector3(0, -1, 0);
   


    private void Start()
    {
        
        moveScript = playerObject.GetComponent<PlayerMovement>();
        
        
    }

    // Start is called before the first frame update
    void OnTriggerEnter (Collider other)
    {

        //the box collider shrinks when it goes into the log
        bc.size += boxSizeChange;
            moveScript.speed -= speedReduction;
            logTriggered = true;
       
            

    }
    //Something is wrong with this part of the script
    private void OnTriggerExit(Collider other)
    {   //the box collider changes size gaining the amount of hieght lost at when going into the log
        bc.size -= boxSizeChange;
      
        moveScript.speed += speedReduction;
        logTriggered = false;
     
    }
    
}
