using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landingPage : MonoBehaviour
{
    public GameObject creditsPage;

    
    public void Quit()
    {
        Application.Quit();
    }

    public void showCredits()
    {
        creditsPage.SetActive(true);

    }

    public void closeCredits()
    {
       
        creditsPage.SetActive(false);
    }
}
