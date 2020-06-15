using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugAnimationTrigger : MonoBehaviour
{

    //for player animations ================
    //======================================
    public GameObject animationObject;
    Animator anim;

    private void Start()
    {
        anim = animationObject.GetComponent<Animator>();


    }
    private void OnTriggerEnter(Collider colliderObject)
    {
        if(colliderObject.gameObject.name == "Bug")
        {
            anim.SetBool("bugFlyAnimation", true);
        }        
    }

    private void OnTriggerExit(Collider colliderObject)
    {
        if (colliderObject.gameObject.name == "Bug")
        {
            anim.SetBool("bugFlyAnimation", false);
        }
    }
}
