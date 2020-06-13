using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class enemyMovement : MonoBehaviour
{
    NavMeshAgent agent;

    //The path the enemy will take
    bool gameStarts = true;
    bool waypoint1;
    bool waypoint2;
    bool waypoint3;
    
    //The Dictionary of Enemy Positions on the path it takes
    public Transform[] enemyPosition;

    //what has the enemy stolen?
    public bool stoleFeather;
    public bool stoleAir;
    public bool stoleLeaf;

    //the locations the ingrediants should be returned to
    Transform featherPosition;
    Transform airPosition;
    Transform leafPosition;

    //the location of the enemy so it stops in place when caught
    Transform stopMove;

    public BoxCollider boxCollider;

    //tells the enemy attack script to give the player back the most recent ingrediant
    public bool gotBack;

    private void Start()
    {        
      
        agent = GetComponent<NavMeshAgent>();

       //The location the ingredients should be returned to
        featherPosition = GameObject.Find("Feather Position").transform;
        airPosition = GameObject.Find("Air Position").transform;
        leafPosition = GameObject.Find("Leaf Position").transform;

        //the location of the enemy so it stops in place when caught
        stopMove = this.gameObject.transform;
    }

    private void Update()
    {
        //for testing purposes
        if (Input.GetKeyDown("f"))
        {
            newPosition();
        }

       //tells the enemy to return ingredients once it has stolen one. 
        returningredient();
    }


    public void newPosition() //enemy moves to the next enemy position  using the array
    { if( gameStarts == true)
        {
            agent.SetDestination(enemyPosition[0].position);
            gameStarts = false;
            waypoint1 = true;
            Debug.Log("game starts");
        }
    else if (waypoint1 == true)
        {
            agent.SetDestination(enemyPosition[1].position);
            waypoint1 = false;
            waypoint2 = true;
            Debug.Log("waypoint 1");
        }
    else if (waypoint2 == true)
        {
            agent.SetDestination(enemyPosition[2].position);
            waypoint2 = false;
            waypoint3 = true;
            Debug.Log("waypoint 2");

        }
    else if (waypoint3 == true)
        {
            agent.SetDestination(enemyPosition[3].position);
            waypoint3 = false;
            Debug.Log("waypoint 3");
        }
    }

    void returningredient() //the enemy returns the ingredients based on which ingredient is stolen.
    {
        if (stoleFeather == true)
        {
            agent.SetDestination(featherPosition.position);
            Debug.Log("feather position");
        }
        else if (stoleAir == true)
        {
            agent.SetDestination(airPosition.position);
            Debug.Log("air position");
        }
        else if (stoleLeaf == true)
        {
            agent.SetDestination(leafPosition.position);
            Debug.Log("leaf position");
        }
        //agent.SetDestination(enemyPosition[Random.Range(0, enemyPosition.Length)].position);

    }

    private void OnTriggerEnter(Collider colliderdObject)  //for when the enemy is caught by the player
    {
       if(colliderdObject.gameObject.name == "Player")// and the enemy has stolen something 
        {
            agent.SetDestination(stopMove.position); //any stops in place
            
            triggerDisappear();
          
            stoleFeather = false;
            stoleAir = false;
            stoleLeaf = false;

            gotBack = true; //gives the player back their ingredient

            Invoke("newPosition", 5f); //enemy moves to next enemy position after 5 sec
        }
    }
    // the trigger will disappear and then reappear to avoid being triggered twice or more on accident
    void triggerDisappear()
    {
        boxCollider.enabled = false;
        Invoke("triggerAppear", 10f);
    }

    void triggerAppear()
    {
        boxCollider.enabled = true;
    }
}
