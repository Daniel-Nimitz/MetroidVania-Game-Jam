using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forthwindsThemeTrigger : MonoBehaviour
{
    audioManager audioScript;
    GameObject audioObject;
    private void Start()
    {
        audioObject = GameObject.Find("AudioManager");
        audioScript = audioObject.GetComponent<audioManager>();
    }

    private void OnTriggerEnter(Collider colliderObject)
    {
        if (colliderObject.gameObject.name == "Player")
        {
            audioScript.ForthwindsTheme();
        }

    }
}
