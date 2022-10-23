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

      public GameObject [] foodIcons1;
      public GameObject [] foodIcons2;
      public GameObject [] foodIcons3;
      public int [] currentItemNums;



      void Start(){
            UpdateScore();
            ListRefresh();
      }

      void Update(){
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

      public void ListRefresh(){
            ListItemRefresh(1,2); 
            ListItemRefresh(2,4); 
            ListItemRefresh(3,5); 
      }
      public void ListItemRefresh(int itemnum, int foodnum=8){

      currentItemNums[itemnum-1] = foodnum;

      if(currentItemNums[0]==8 && currentItemNums[1]==8 && currentItemNums[2]==8){
            //extra big vfx
            ListRefresh();
      }

      
      if (itemnum==1){
            foreach (var icon in foodIcons1)
                  {icon.SetActive(false);}
            foodIcons1[currentItemNums[itemnum-1]].SetActive(true);
      }
      else if (itemnum==2){
            foreach (var icon in foodIcons2)
                  {icon.SetActive(false);}
            foodIcons2[currentItemNums[itemnum-1]].SetActive(true);
      }
      else if (itemnum==3){
            foreach (var icon in foodIcons3)
                  {icon.SetActive(false);}
            foodIcons3[currentItemNums[itemnum-1]].SetActive(true);
      }
      else {
            print("Only 3 items in list");
      }

      }

      
      public string getItemName(int itemnum){
            return foodIcons1[currentItemNums[itemnum-1]].name;
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

