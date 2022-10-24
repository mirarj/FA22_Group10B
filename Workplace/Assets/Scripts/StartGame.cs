using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    
    public void testprint(){
        print("clicked");
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadInstructions()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadStart()
    {
        SceneManager.LoadScene(0);
    }
}
