using UnityEngine.Audio;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioSource[] audioSources = new AudioSource[8];

   public bool spiritPlaying;


    // audioManager audioScript;
    //GameObject audioObject;
    //audioObject = GameObject.Find("AudioManager");
    //audioScript = audioObject.GetComponent<audioManager>();

    //[0] Main Theme
    //[1] You Bug Me
    //[2] A spirtiual Encounter
    //[3] Forthwinds theme
    //[4] REMOVED
    //[5] Reward theme
    //[6] Chimes

    private void Awake()
    {
        YouBugMe();
    }

    private void Update()
    {
        if (spiritPlaying == false) 
        {
            audioSources[2].enabled = false;
        }
    }
    public void MainMusic()  //0
    {
        if(spiritPlaying == false)
        {
            audioSources[0].enabled = true;
            audioSources[1].enabled = false;

            audioSources[3].enabled = false;
            audioSources[4].enabled = false;
            audioSources[5].enabled = false;
            audioSources[6].enabled = false;
        }
        
   
    }

    public void YouBugMe()  //1
    {
        if (spiritPlaying == false)
        {
            audioSources[0].enabled = false;
            audioSources[1].enabled = true;

            audioSources[3].enabled = false;
            audioSources[4].enabled = false;
            audioSources[5].enabled = false;
            audioSources[6].enabled = false;
        }
        
        
    
    }
    
   public void SpiritualEncounter() //2
    {
        spiritPlaying = true;
        
        audioSources[0].enabled = false;
        audioSources[1].enabled = false;
        audioSources[2].enabled = true;
        audioSources[3].enabled = false;
        audioSources[4].enabled = false;
        audioSources[5].enabled = false;
        audioSources[6].enabled = false;
      
    }

    public void ForthwindsTheme()//3
    {
        if (spiritPlaying == false)
        {
            audioSources[0].enabled = false;
            audioSources[1].enabled = false;

            audioSources[3].enabled = true;
            audioSources[4].enabled = false;
            audioSources[5].enabled = false;
            audioSources[6].enabled = false;
        }

           
    
    }

    public void Reward()//5
    {
        audioSources[5].enabled = true;       
    }

    public void Chimes()//6
    {
     
        audioSources[6].enabled = true;
       
    }

}


//[0] Main Theme
//[1] You Bug Me
//[2] A spirtiual Encounter
//[3] Forthwinds theme
//[4] REMOVED
//[5] Reward theme
//[6] Chimes