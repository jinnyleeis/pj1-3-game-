using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager :MonoBehaviour
{
    static public float hp=100;
    static public int score=0;
    static public int coinCnt=0;
    static public int TrapCnt=0;
    static public int potionCnt=0;

void Update() {
    

  // score+=Settings.COIN_SCORE;
  // hp +=Settings.POTION_SCORE;
  // hp -=Settings.TRAP_SCORE;
   }

    //외부 호출용임
    

    static public void AddCoin()
    {
        coinCnt++;
        score+=10;
    }

     static public void AddTrap()
    {
        TrapCnt++;
        hp-=10;
    }
static public void AddPotion()
    {

        potionCnt++;
        hp+=5;

    }
    //득점시,
    static public void AddScore(int _score)
    {
      
        score+= _score;
   }

//hp 회복시,
static public void AddHp(int _hp)
    {
      
        hp+= _hp;
   }
    

   
   

}

public class Settings
{

//for game managing 
public const float HP = 100;

//item 
public const int COIN_SCORE=10;
public const int POTION_SCORE=5;
public const int TRAP_SCORE=-10;
public const int HP_DEC=2;
public const int HP_ADD=10;

//static public float PlayerHP
///{
   // get{return HP;}
//}

}

//ENEMY 관련은 별도의 클래스에다. 