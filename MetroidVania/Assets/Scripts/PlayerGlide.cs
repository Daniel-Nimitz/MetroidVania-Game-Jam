using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerGlide : MonoBehaviour
{
    // Start is called before the first frame update
    public double gravity = 10;
    public bool isOnGround;
    private float flightTime = 0f;
    public float maxFlightTime = 3.0f;

    //Define some private variables here for changes on gravity and directional force.
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Executes while the player is gliding and sets the gravity to 1/2 of normal.
        while (Input.GetButtonDown("E") && isOnGround == false && flightTime < maxFlightTime)
            {
            gravity *= 0.5;
            // a line for the animation to initialize
            flightTime += Time.deltaTime;
            }

        //Stops glide if the player is gliding more than the maximum duration
        if (Input.GetButtonUp("E") || flightTime >= maxFlightTime  && isOnGround == false)
        {
            //Stop the gliding animation
            //Begin the falling animation
        }

        //Returns the gravity to normal and the flight time counter to 0.
        flightTime = 0;
        gravity = 10;

    }
}
