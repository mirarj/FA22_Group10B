using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    AudioSource gameover;
    private string endGame;
    // Start is called before the first frame update
    void Start()
    {
        // endGame = SceneManager.GetActiveScene();
        gameover.playOnAwake = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
