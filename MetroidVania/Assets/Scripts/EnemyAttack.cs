﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange;
    public GameObject target;
    public GameObject recipeUI;

    private recipeManager recipeScript;


    // Start is called before the first frame update
    void Start()
    {
        recipeScript = recipeUI.GetComponent<recipeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, target.transform.position);
        if (playerDistance <= attackRange) {
            Attack();
        }
    }
    public void Attack() {
        print("Player has been attacked");
        int stolenIngredient = Random.Range(0, recipeScript.Ingredients.Count);
        recipeScript.Ingredients["Old Leaves Of The First Tree"] = false;
    }
}
/*To Do:
 * Set up something tracking the last ingredient picked up
 * Have the enemy delete the last ingredient picked up when it attacks
 * Make it so the enemy only attacks once per given amount of time, only attacks when at an enemy position
 * need to tell booleans if true or false
 * dont attack if have stolen item
 * call returnIngredient function when attack happens, tell the code which 
 * 
 * gotBack is variable boolean in player movement script telling players what they have received
 */
