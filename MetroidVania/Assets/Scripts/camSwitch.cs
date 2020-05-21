using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class camSwitch : MonoBehaviour
{
    //this calls the animator so we can refrence it below
    Animator anim;
    public bool inSky = false;


    // Start is called before the first frame update
    void Start()
    {
        //I honestly don't know what this does but its important
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (inSky == false && Input.GetKeyDown("o"))
        {
            //moves the camera up to the sky
            anim.SetBool("camTransition", true);
            inSky = true;
            
        }

        else if (inSky == true && Input.GetKeyDown("o"))
        {
            anim.SetBool("camTransition", false);
            inSky = false;
        }
        
    }


}
