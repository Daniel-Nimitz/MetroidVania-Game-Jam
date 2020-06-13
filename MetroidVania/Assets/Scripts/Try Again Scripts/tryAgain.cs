using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// Send the player back to their post recent secret spawn point

public class tryAgain : MonoBehaviour
{

    public bool secretSpawnA;
    public bool secretSpawnB;
    public bool secretSpawnC;
    public bool secretSpawnD;
    public bool secretSpawnE;
    public bool secretSpawnF;
    public bool secretSpawnG;
    public bool secretSpawnH;

    public GameObject[] teleportDestinations;
    


    public GameObject tryAgainPanel;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] teleportDestinations = new GameObject[8];


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider colliderObject)
    {
        Debug.Log("death!");
        if (secretSpawnA == true && colliderObject.name == "Player")
        {
            colliderObject.transform.position = teleportDestinations[0].transform.position;    //change the colliders position to secret Spawn point

            tryAgainPanel.SetActive(true);

            Invoke("returnScreen", .5f);
        }

        else if (secretSpawnB == true && colliderObject.name == "Player")
        {
            colliderObject.transform.position = teleportDestinations[1].transform.position;   //change the colliders position to secret Spawn point

            tryAgainPanel.SetActive(true);

            Invoke("returnScreen", .5f);
        }
        
        else if (secretSpawnC == true && colliderObject.name == "Player")
        {
            colliderObject.transform.position = teleportDestinations[2].transform.position;    //change the colliders position to secret Spawn point

            tryAgainPanel.SetActive(true);

            Invoke("returnScreen", .5f);
        }
        
        else if (secretSpawnD == true && colliderObject.name == "Player")
        {
            colliderObject.transform.position = teleportDestinations[3].transform.position;    //change the colliders position to secret Spawn point

            tryAgainPanel.SetActive(true);

            Invoke("returnScreen", .5f);
        }

        else if (secretSpawnE == true && colliderObject.name == "Player")
        {
            colliderObject.transform.position = teleportDestinations[4].transform.position;  //change the colliders position to secret Spawn point

            tryAgainPanel.SetActive(true);

            Invoke("returnScreen", .5f);
        }
        
        else if (secretSpawnF == true && colliderObject.name == "Player")
        {
            colliderObject.transform.position = teleportDestinations[5].transform.position;    //change the colliders position to secret Spawn point

            tryAgainPanel.SetActive(true);

            Invoke("returnScreen", .5f);
        }
        
        else if (secretSpawnG == true && colliderObject.name == "Player")
        {
            colliderObject.transform.position = teleportDestinations[6].transform.position;   //change the colliders position to secret Spawn point

            tryAgainPanel.SetActive(true);

            Invoke("returnScreen", .5f);
        }
        
        else if (secretSpawnH == true && colliderObject.name == "Player")
        {
            colliderObject.transform.position = teleportDestinations[7].transform.position;   //change the colliders position to secret Spawn point

            tryAgainPanel.SetActive(true);

            Invoke("returnScreen", .5f);
        }
    }

    void returnScreen()
    {
        tryAgainPanel.SetActive(false);

        secretSpawnA = false;
        secretSpawnB = false;
        secretSpawnC = false;
        secretSpawnD = false;
        secretSpawnE = false;
        secretSpawnF = false;
        secretSpawnG = false;
        secretSpawnH = false;
    }


}
