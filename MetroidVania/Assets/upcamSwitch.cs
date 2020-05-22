using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upcamSwitch : MonoBehaviour
{
    Animator anim;
    logTrigger logScript;
    public GameObject logtriggerObject;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        logScript = logtriggerObject.GetComponent<logTrigger>();
        
    }

    // Update is called once per frame
    void Update()
    {if (logScript.logTriggered == true)
        {
            anim.SetBool("upcamTransition", true);
        }
    else
        {
            anim.SetBool("upcamTransition", false);
        }
    }
}
