using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rescueanimalpig : MonoBehaviour
{

    private float hp=Settings.HP;
    Animator animator;


    void Start() {
          animator = GetComponent<Animator>();
    }

     void AddHP()
     {
         hp+=Settings.HP_ADD;
        //hp=Mathf.Clamp(hp,0,Settings.PlayerHP);

     }

     //public GameObject coinscoreresource;
     public AudioClip coinsoundresource;
    // trigger enter
    void  OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag=="aconite")
       {
           SetScore();
       } 
    }

    //collision enter
    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.transform.tag=="aconite")
        {

            SetScore();
        }
        
    } 

    void SetScore()
    {
        Vector3 pos =transform.position+new Vector3(0,0.5f,0);
        animator.SetBool("rescued", true);
        //GameObject coinscore = Instantiate(coinscoreresource,transform.position,transform.rotation) as GameObject;

        //coinscore.SendMessage("SetScore",Settings.COIN_SCORE);
        ScoreManager.AddPotion();

        //coin sound 
        AudioClip coinsound=Instantiate(coinsoundresource) as AudioClip;
        AudioSource.PlayClipAtPoint(coinsound,pos);

        Destroy(gameObject);

    }
        
    
}
