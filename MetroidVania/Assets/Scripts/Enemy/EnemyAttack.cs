using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange;
    public GameObject target;
    public GameObject recipeUI;

    private recipeManager recipeScript;

    enemyMovement enemyMovementScript;

//music
    audioManager audioScript;
    GameObject audioObject;


    // Start is called before the first frame update
    void Start()
    {
        recipeScript = recipeUI.GetComponent<recipeManager>();

        enemyMovementScript = this.GetComponent<enemyMovement>();

        audioObject = GameObject.Find("AudioManager");
        audioScript = audioObject.GetComponent<audioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider colliderObject)
    {
        if( colliderObject.gameObject.name == "Player" && enemyMovementScript.canAttack == true)
        {
           
                Attack();
            enemyMovementScript.canAttack = false;
        }
       
    }
        
    

    
    public void Attack() 
    {
        if (recipeScript.hasSomething == true)
        {
            recipeScript.removeIngred();
            Debug.Log("The enemy is attacking");

            audioScript.SpiritualEncounter();
        }
    }

   
}
