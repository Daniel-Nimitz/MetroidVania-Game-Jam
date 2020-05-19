using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camSwitch : MonoBehaviour
{
    //this calls the animator so we can refrence it below
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //I honestly don't know what this does but its important
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("o"))
        {
            //moves the camera up to the sky
            anim.SetBool("camTransition", true);
        }
        if (Input.GetKeyDown("t"))
        {
            //moves the camera back down to the player
            anim.SetBool("camTransition", false);
        }
    }

}
