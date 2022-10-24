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
                  gameMin=0; gameSec=0;
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
                  string grade="X";
                  if (playerScore<10) {grade="F";}
                  else if (playerScore<25) {grade="D";}
                  else if (playerScore<40) {grade="C";}
                  else if (playerScore<60) {grade="B";}
                  else if (playerScore<100) {grade="A";}
                  else if (playerScore<100) {grade="D";}
                  else {grade="S+";}
                  
                  scoreTextB.text = "FINAL SCORE: " + grade + "  (" + playerScore + ")";
            }
            else {
                  scoreTextB.text = "" + playerScore;
            }

      }

      public void ListRefresh(){
            ListItemRefresh(1,Random.Range(0,7)); 
            ListItemRefresh(2,Random.Range(0,7)); 
            ListItemRefresh(3,Random.Range(0,7)); 
      }
      public void ListItemRefresh(int itemnum, int foodnum=8){

      currentItemNums[itemnum-1] = foodnum;

      if(currentItemNums[0]==8 && currentItemNums[1]==8 && currentItemNums[2]==8){
            //extra big vfx
            AddScore(8);
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

