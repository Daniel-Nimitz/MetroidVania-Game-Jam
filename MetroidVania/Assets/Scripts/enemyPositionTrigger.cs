using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPositionTrigger : MonoBehaviour
{
    enemyMovement enemyMovementScript;
    public GameObject enemyObject;

    recipeManager recipeScript;
    public GameObject recipeUI;

    private void Start()
    {
        enemyMovementScript = enemyObject.GetComponent<enemyMovement>();

        recipeScript = recipeUI.GetComponent<recipeManager>();
    }

    private void OnTriggerEnter(Collider colliderObject)
    {
        if(colliderObject.gameObject.name == "Enemy" )
        {
            enemyMovementScript.canAttack = true;
            
           
        }
    }

   
   

}
