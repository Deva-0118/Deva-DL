using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Control : MonoBehaviour
{
    // Start is called before the first frame updatevoid start()
    void start()
    { 
    
    }
    // Update is called once per framevoid ypdate()
    void update() 
    {
    
    }
    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("The button is working.");
    }
 
}

