using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

     //public GameObject coinscoreresource;
     public AudioClip coinsoundresource;
    // trigger enter
    void  OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag=="Player")
       {
           SetScore();
       } 
    }

    //collision enter
    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.transform.tag=="Player")
        {

            SetScore();
        }
        
    } 

    void SetScore()
    {
        Vector3 pos =transform.position+new Vector3(0,0.5f,0);
        //GameObject coinscore = Instantiate(coinscoreresource,transform.position,transform.rotation) as GameObject;

        //coinscore.SendMessage("SetScore",Settings.COIN_SCORE);
        ScoreManager.AddCoin();

        //coin sound 
        AudioClip coinsound=Instantiate(coinsoundresource) as AudioClip;
        AudioSource.PlayClipAtPoint(coinsound,pos);

        Destroy(gameObject);

    }
        
    
}
