using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpTrigger : MonoBehaviour
{
    //for tutorial message
    GameObject tutorialObject;
    tutorialManager tutorialScript;
    public BoxCollider bc;

    private void Start()
    {
        // fills boxes for tutorial message
 
         tutorialObject = GameObject.Find("Tutorial UI");
         tutorialScript = tutorialObject.GetComponent<tutorialManager>();

      
                
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider colliderObject)
    {
        if(colliderObject.name == "Player")
        {
            tutorialScript.startJump();
            bc.enabled = false;
        }
    }
}
