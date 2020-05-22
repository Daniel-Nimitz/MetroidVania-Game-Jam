using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitButton : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }
}
