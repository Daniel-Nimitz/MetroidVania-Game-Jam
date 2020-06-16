using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secretSpawnG : MonoBehaviour
{
    tryAgain tryAgainscript;
    GameObject death;

    private void Start()
    {
        death = GameObject.Find("Start Over");
        tryAgainscript = death.GetComponent<tryAgain>();
    }
    private void OnTriggerEnter(Collider colliderObject)
    {
        
        if (colliderObject.name == "Player")
        {
            tryAgainscript.secretSpawnG = true;
        }
    }
}
