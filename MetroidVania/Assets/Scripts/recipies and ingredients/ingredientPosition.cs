using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
//This script tells the enemy it no longer has ANY ingredients once it 
//has succesfully returned a stolen ingredient and then send the enemy to its next waypoint
public class ingredientPosition : MonoBehaviour
{
    //used to refrence the enemy movement script
    GameObject Enemy;
    enemyMovement enemyMovement;
    public BoxCollider boxCollider;

    public GameObject featherObject;
    public GameObject airObject;
    public GameObject leafObject;

    //music
    audioManager audioScript;
    GameObject audioObject;


    void Start()
    {
        Enemy = GameObject.Find("Enemy");
        enemyMovement = Enemy.GetComponent<enemyMovement>();

        audioObject = GameObject.Find("AudioManager");
        audioScript = audioObject.GetComponent<audioManager>();

    }

   
    void OnTriggerEnter(Collider colliderObject)
    {
        if (colliderObject.gameObject.name == "Enemy")
        {
           if(enemyMovement.stoleFeather == true)
            {
                featherObject.SetActive(true);
            }

            if (enemyMovement.stoleLeaf == true)
            {
                leafObject.SetActive(true);
            }

            if (enemyMovement.stoleAir == true)
            {
                airObject.SetActive(true);
            }

            triggerDisappear();
        
            enemyMovement.stoleFeather = false;
            enemyMovement.stoleAir = false;
            enemyMovement.stoleLeaf = false;

           

            enemyMovement.Invoke("newPosition", 0f);

            audioScript.spiritPlaying = false;

            
            
            //make is so the ingredine game object reappears <-------------------------
        }
                                  
    }
// the trigger will disappear and then reappear to avoid being triggered twice on accident
    void triggerDisappear()
    {
        boxCollider.enabled = false;
        Invoke("triggerAppear", 3f);
    }

    void triggerAppear()
    {
        boxCollider.enabled = true;
    }

}
