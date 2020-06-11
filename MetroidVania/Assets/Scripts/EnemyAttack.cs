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
    
    }
}
