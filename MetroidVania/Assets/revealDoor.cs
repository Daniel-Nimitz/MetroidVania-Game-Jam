using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Makes the door diseapper when the player press "o" and uses bug vision and then reappear when they return to normal vision after 5 secondends 
public class revealDoor : MonoBehaviour
{
    camSwitch bugviewScript;
    public GameObject cameraAnimator;
    public BoxCollider doorOn;
    bool sawDoor;
    public MeshRenderer showDoor;

    // Start is called before the first frame update
    void Start()
    {
        bugviewScript = cameraAnimator.GetComponent<camSwitch>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (bugviewScript.inSky == true)
        {
            doorOn.enabled = false;
         
            sawDoor = true;
            showDoor.enabled = false;
        }

        if (sawDoor == true && bugviewScript.inSky == false)
        {
            Invoke("doorDisappear", 3);
        }
        
                 
        
        
    }
    public void doorDisappear()
    {
        doorOn.enabled = true;
        sawDoor = false;
        showDoor.enabled = true;
     
    }
}
