using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;
// This script allows the player to see the recipe and ingrediants they have.
public class recipeManager : MonoBehaviour
{
    public bool hasRecipe = false; // This switch wont allow the player to open the recipe screen if they have no recipes.
    public GameObject recipeAPanel; //box for the Recipe A Panel.
    bool menuOpen = false; //for opening and closing the recipe Canas with the same key.

    // For HUD stuff =====================
    //====================================
    public GameObject recipeHUD;
    public GameObject airCheck;
    public GameObject featherCheck;
    public GameObject leafCheck;

    bool airCheckTrue;
    bool featherCheckTrue;
    bool leafCheckTrue;


    //boxes to acxess the player movement script to enable double jump. ======
    //========================================================================
    private PlayerMovement movementScript;
    public GameObject player;

    //boxes to acxess the enemy  movement script =============================
    //========================================================================
    enemyMovement enemyMoveScript;
    public GameObject enemy;


    //The dictionary where ingredients will go
    public List<string> ingredients = new List<string>();
    string lastIngredient;


    //for tutorial message
    GameObject tutorialObject;
    tutorialManager tutorialScript;

    public bool hasSomething;

    bool returnAir;
    bool returnFeather;
    bool returnLeaf;

    public bool alreadyStole = false;

    //music
    audioManager audioScript;
    GameObject audioObject;


    void Start()
    {
        enemyMoveScript = enemy.GetComponent<enemyMovement>();

        //the player movement boxes are filled so we can enable double jump.
        movementScript = player.GetComponent<PlayerMovement>();

        //fills boxes for tutorial message
        tutorialObject = GameObject.Find("Tutorial UI");
        tutorialScript = tutorialObject.GetComponent<tutorialManager>();

        ingredients.Add("placeholder");

        audioObject = GameObject.Find("AudioManager");
        audioScript = audioObject.GetComponent<audioManager>();
    }

   

 

    void Update()
    {

 // The player now has an ingredient, what do we do with it? =====================================================================
 //===============================================================================================================================

        if (movementScript.gotAir == true)
        {
            airCheck.SetActive(true);
            airCheckTrue = true;

            ingredients.Add("Air");
            Debug.Log("Air added to list");

            movementScript.gotAir = false;

            hasSomething = true;
        }


        if (movementScript.gotFeather == true)
        {
            featherCheck.SetActive(true);
            featherCheckTrue = true;
            ingredients.Add("Feather");
            Debug.Log("Featger added to list");


            movementScript.gotFeather = false;

            hasSomething = true;
        }


        if (movementScript.gotLeaf == true)
        {
            leafCheck.SetActive(true);
            leafCheckTrue = true;
            ingredients.Add("Leaf");
            Debug.Log("Leaf added to list");

            movementScript.gotLeaf = false;

            hasSomething = true;
        }

        

//if the player has ALL ingredients then they can double jump =================================================================================
//=============================================================================================================================================
        if (airCheckTrue == true && leafCheckTrue == true && featherCheckTrue == true)
        {
            movementScript.doubleJumpUnlocked = true;

            audioScript.Reward();
        }

       


//The recipe HUD and Menu =====================================================================================================================
//=============================================================================================================================================

        if (hasRecipe == true)  //activates a image on the recipe Canvas
        {
            recipeHUD.SetActive(true);
        }
        if (menuOpen == false && hasRecipe == true && Input.GetKeyUp(KeyCode.Tab)) //Tab key opens the canvas which holds the  recipe panel if the player has a recipe and presses tab.
        {
            recipeAPanel.SetActive(true);
            menuOpen = true;

            tutorialScript.endrecipe();

        }
        else if (menuOpen == true && Input.GetKeyUp(KeyCode.Tab))   //Tab key closes the canvas if the canvas is already open.
        {
            recipeAPanel.SetActive(false);
            menuOpen = false;
        }

    }

 
//the enemy has removed an ingredient after attacking the player====================================
//==================================================================================================
    public void removeIngred()
    {
        enemyMoveScript.returningredient();

        if (alreadyStole == false)
        {
            
            lastIngred();
            alreadyStole = true;



            if (lastIngredient == ("Air"))
            {
                ingredients.Remove("Air");
                airCheck.SetActive(false);
                airCheckTrue = false;
                

                enemyMoveScript.stoleAir = true; //tells the enemy which thing was stolen

                returnAir = true;

                
            }

            else if (lastIngredient == ("Feather") )
            {
                ingredients.Remove("Feather");
                featherCheck.SetActive(false);
                featherCheckTrue = false;
                

                enemyMoveScript.stoleFeather = true; //tells the enemy which thing was stolen    

                returnFeather = true;
            }

            else if (lastIngredient == ("Leaf") )
            {
                ingredients.Remove("Leaf");
                leafCheck.SetActive(false);
                leafCheckTrue = false;
                

                enemyMoveScript.stoleLeaf = true;

                returnLeaf = true;
            }

            Invoke("StoleAlready", 1f);
           

        }
    }



    public void lastIngred()
    {
        lastIngredient = ingredients.Last();
    }
//===========================================================================================
//===========================================================================================


public void StoleAlready()
    {
        alreadyStole = false;
    }

//when the player gets the ingredient back from the enemy ===================================================================
//===========================================================================================================================
    public void giveBack()
    {
        Debug.Log("giveBack called");

        enemyMoveScript.canAttack = false;

        if (returnAir == true)
        {
            ingredients.Add("Air");
            airCheck.SetActive(true);
            airCheckTrue = true;

            if(airCheckTrue == true)
            {
                Debug.Log("air check");
            }

            
            
            

            enemyMoveScript.stoleAir = false; //tells the enemy which thing was stolen
            returnAir = false;
        }

        if (returnFeather == true)
        {
            ingredients.Add("Feather");
            featherCheck.SetActive(true);
            featherCheckTrue = true;

            Debug.Log("feather returned to player");
           

            enemyMoveScript.stoleFeather = false; //tells the enemy which thing was stolen
            returnFeather = false;
        }

        if (returnLeaf == true)
        {
            ingredients.Add("Leaf");
            leafCheck.SetActive(true);
            leafCheckTrue = true;

            Debug.Log("leaf returned to player");

            enemyMoveScript.stoleLeaf = false;
            returnLeaf = false;
        }
    }
    //=====================================================================================================================================================
    //=====================================================================================================================================================

}
