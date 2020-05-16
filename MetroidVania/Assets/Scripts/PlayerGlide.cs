using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlide : MonoBehaviour
{
    // Start is called before the first frame update

    //Define some private variables here for changes on gravity and directional force.
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    //This will change the player's gravity
    /* Note to Alex: change the players gravity as an if or while loop(if player holds down space).
     * Player gravity = rigidbody (weight) of player by probably 75% until they land on the ground. 
     * Maybe even make a little updraft = Force in upwards direction.
     * Cancel when player hits the ground or a dropbox. */
    
    //This will allow the player to change direction while gliding
    /*Change the way the arrow keys works but just for the glide.
     * Potentially have them add force to the players direction.
     * Gliding will be kind of like controlling the win. */

    }
}
