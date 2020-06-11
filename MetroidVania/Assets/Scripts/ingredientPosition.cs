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


    void Start()
    {
        Enemy = GameObject.Find("Enemy");
        enemyMovement = Enemy.GetComponent<enemyMovement>();
            
    }

   
    void OnTriggerEnter(Collider colliderObject)
    {
        if (colliderObject.gameObject.name == "Enemy")
        {
            triggerDisappear();
        
            enemyMovement.stoleFeather = false;
            enemyMovement.stoleAir = false;
            enemyMovement.stoleLeaf = false;

            Debug.Log("ingredients returned");

            enemyMovement.Invoke("newPosition", 0f);
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
