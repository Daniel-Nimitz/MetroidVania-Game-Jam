using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialManager : MonoBehaviour
{
    public GameObject wasdPanel;

    public GameObject bugPanel;

    public GameObject recipePanel;

    public GameObject stolePanel;

    public GameObject jumpPanel;



    private void Start()
    {
        Invoke("startWASD", 1f);
    }
    //how to walk tutorial
    void startWASD()
    {
        wasdPanel.SetActive(true);
        Invoke("endWASD", 3f);
    }
    void endWASD()
    {
        wasdPanel.SetActive(false);
    }
// how to jump
   public void startJump()
    {
        jumpPanel.SetActive(true);
        Invoke("endJump", 3f);
    }

    void endJump()
    {
        jumpPanel.SetActive(false);
    }


//how to bug tutorial

   public void startBug()
    {
        bugPanel.SetActive(true);
    }

    public void endBug()
    {
        bugPanel.SetActive(false);
    }

//how to recipe
    public void startrecipe()
    {
        recipePanel.SetActive(true);
        
    }

    public void endrecipe()
    {
        recipePanel.SetActive(false);
    }

//how to steal
    public void startsteal()
    {
        stolePanel.SetActive(true);

    }

    public void endsteal()
    {
        stolePanel.SetActive(false);
    }

}
