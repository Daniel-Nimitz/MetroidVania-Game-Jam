using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;
// This script allows the player to see the recipe and ingrediants they have.
public class recipeManager : MonoBehaviour
{
    public bool hasRecipe = false; // This switch wont allow the player to open the recipe screen if they have no recipes.
    public GameObject recipeAPanel; //box for the Recipe A Panel.
    bool menuOpen = false; //for opening and closing the recipe Canas with the same key.
    public GameObject recipeHUD;  //shows the player on the screen they have a recipe
    public GameObject airCheck;
    public GameObject featherCheck;
    public GameObject leafCheck;
    bool found;

    //boxes to acxess the player movement script to enable double jump.
    private PlayerMovement movementScript;
    public  GameObject player;

    //The dictionary where ingredients will go
    public Dictionary<string, bool> Ingredients = new Dictionary<string, bool>();

        



// Start is called before the first frame update
void Start()
{   // The dictionary of ingredients is populated.

        Ingredients.Add("Essence Of Air", false);
        Ingredients.Add("Feather of Placeholder", false);
        Ingredients.Add("Old Leaves Of The First Tree", false);

    //the player movement boxes are filled so we can enable double jump.
        movementScript = player.GetComponent<PlayerMovement>();
          

}

    // Update is called once per frame
    void Update()
    {
        //The recipe HUD and menu

        if (hasRecipe == true)  //activates a image on the recipe Canvas
        {
            recipeHUD.SetActive(true);
        }
        if (menuOpen == false && hasRecipe == true && Input.GetKeyUp(KeyCode.Tab)) //Tab key opens the canvas which holds the  recipe panel if the player has a recipe and presses tab.
        {
            recipeAPanel.SetActive(true);
            menuOpen = true;
        }
        else if (menuOpen == true && Input.GetKeyUp(KeyCode.Tab))   //Tab key closes the canvas if the canvas is already open.
        {
            recipeAPanel.SetActive(false);
            menuOpen = false;
        }
    
//If the player has any ingredient then
        if (Ingredients.TryGetValue("Essence Of Air", out found) && found == true)
        {
            airCheck.SetActive(true);               
        }

        else
        {
            airCheck.SetActive(false);
        }
       
        if (Ingredients.TryGetValue("Feather of Placeholder", out found) && found == true)
        {
            featherCheck.SetActive(true);
        }

        else
        {
            featherCheck.SetActive(false);
        }

        if (Ingredients.TryGetValue("Old Leaves Of The First Tree", out found) && found == true)
        {
            leafCheck.SetActive(true);
        }

        else
        {
            leafCheck.SetActive(false);
        }
//if the player has ALL ingredients then they can double jump
        if (Ingredients.TryGetValue("Essence Of Air", out found) && Ingredients.TryGetValue("Old Leaves Of The First Tree", out found) && Ingredients.TryGetValue("Feather of Placeholder", out found) && found == true)
        {
            movementScript.doubleJumpUnlocked = true;
        }


    }
}
