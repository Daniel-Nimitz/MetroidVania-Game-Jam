using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// THis is the bug vision. Press "o" to have your bug fly up and unlock a blocked door. While doing this the player can't move forward or back but can turn in a cirlce. 
/// </summary>
public class camSwitch : MonoBehaviour
{
    //this calls the animator so we can refrence it below
    Animator anim;
    public bool inSky = false;
    public GameObject playerObject;
    PlayerMovement moveScript;

    //for tutorial message
    GameObject tutorialObject;
    tutorialManager tutorialScript;


    public GameObject bugfriend;

    public GameObject bugFriendInAir;

    //Music=========
    //==============
    audioManager audioScript;
    GameObject audioObject; 



    // Start is called before the first frame update
    void Start()
    {
        //I honestly don't know what this does but its important
        anim = GetComponent<Animator>();
        moveScript = playerObject.GetComponent<PlayerMovement>();

        //fills boxes for tutorial message
        tutorialObject = GameObject.Find("Tutorial UI");
        tutorialScript = tutorialObject.GetComponent<tutorialManager>();

        //music
        audioObject = GameObject.Find("AudioManager");
        audioScript = audioObject.GetComponent<audioManager>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveScript.bugVisionUnlocked == true && inSky == false && Input.GetKeyDown(KeyCode.LeftShift))
        {
            //moves the camera up to the sky
            anim.SetBool("camTransition", true);
            inSky = true;
            moveScript.speed -= 20;

            //tutorial message stops
            tutorialScript.endBug();

            bugfriend.SetActive(false);
            bugFriendInAir.SetActive(true);

         

        }

        else if (inSky == true && Input.GetKeyDown(KeyCode.LeftShift))
        {
           //move the camera back to the player
            anim.SetBool("camTransition", false);
            inSky = false;
            moveScript.speed = 20f;

            bugfriend.SetActive(true);
            bugFriendInAir.SetActive(false);

        }
        
    }


}
