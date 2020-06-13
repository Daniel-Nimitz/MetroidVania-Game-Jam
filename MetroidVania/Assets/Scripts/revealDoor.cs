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
    public GameObject Player;
    public GameObject doorGraphic;

    // Start is called before the first frame update
    void Start()
    {
        bugviewScript = cameraAnimator.GetComponent<camSwitch>();
       
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(Player.gameObject.transform.position, gameObject.transform.position);
        if (bugviewScript.inSky == true && sawDoor == false && distanceFromPlayer < 40f)
        {
            doorOn.enabled = false;
            sawDoor = true;
            showDoor.enabled = false;
            doorGraphic.SetActive(true);
        }

        if (sawDoor == true && bugviewScript.inSky == false)
        {
            //it is a problem because this is invoked 60x per second
            doorDisappear();
        }
        
    }
    public void doorDisappear() // turn some of these to true to have door reappear
    {
        doorOn.enabled = false;
        sawDoor = false;
        showDoor.enabled = false;
     
    }
}
