using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameHandler : MonoBehaviour {

      public GameObject scoreText;
      public GameObject timeText;
      public int timeLimit = 20;
      private float gameTimer = 0f;
      private int gameMin;
      private int gameSec;
      private static int playerScore = 0;

      public string targetFood1;

      public GameObject [] foodIcons1;
      public string currentItem1Name;
      public int currentItem1Number;



      void Start(){
            UpdateScore();
      }

      void FixedUpdate(){
            if(gameTimer>=timeLimit){
                  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else{
                  gameTimer += 0.02f;
                  gameMin = (int)Mathf.Floor((timeLimit - gameTimer)/60);
                  gameSec = (int)(timeLimit-gameTimer)%60;

                  UpdateTime();
            }
      }
      public void AddScore(int points){
            playerScore += points;
            UpdateScore();
      }

      void UpdateScore(){
            Text scoreTextB = scoreText.GetComponent<Text>();
            if (SceneManager.GetActiveScene().name=="GameOver")
            {
                  scoreTextB.text = "FINAL SCORE: " + playerScore;
            }
            else {
                  scoreTextB.text = "" + playerScore;
            }

      }


      public void ShoppingListItem1(){
            //Randomize an item from the list
            //choose a random number between 0 and array.length -1, set it to currentItem1Number.
            //set currentItem1Name = foodIcons1[randomNum].name;
            //HideAll
            //for all items in the food icon array, seat each to foodIcons1[for loop #].SetActive(false);
            //Reveal current item
            //for current item, foodIcons1[randomNum].SetActive(true);
      }


      public void UpdateTime(){
      timeText.GetComponent<Text>().text = string.Format("{0:00}:{1:00}", gameMin, gameSec);
      }


        public void StartGame(){
                SceneManager.LoadScene("GameScene");
        }

        public void RestartGame(){
            Time.timeScale = 1f;
            playerScore = 0;
            SceneManager.LoadScene("StarterScene");
        }

        public void QuitGame(){
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
        }


}

