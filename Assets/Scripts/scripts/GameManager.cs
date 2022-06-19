using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    
     Text txtScore;
     Text txtHP;
    

    

    GameObject Player;
    Vector3 spPoint;
   

    Vector3 camOffset = new Vector3(3,-2,-10);

   
    // Start is called before the first frame update
    void Awake()
    {
       InitGame();

    }

    void InitGame()
    {
       
     txtHP=GameObject.Find("TxtHP").GetComponent<Text>();
     txtScore=GameObject.Find("TxtScore").GetComponent<Text>();
     

    }


    // Update is called once per frame
    void Update()
    {
        
        SetScore();
        
    }

    void SetScore()
    {

      txtHP.text = ScoreManager.hp.ToString();
      txtScore.text = ScoreManager.score.ToString("#,0");
       //TxtStage.text = ScoreManager.coinCnt.ToString();
      // TxtTime .text= ScoreManager.coinCnt.ToString();
    }
}
