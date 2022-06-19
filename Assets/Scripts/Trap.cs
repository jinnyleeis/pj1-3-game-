using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject trapresource;
     public AudioClip trapsoundresource;
    int damage;
    // Start is called before the first frame update
    void Start()
    {
        damage=10;
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.transform.tag !="Player") return;
        Vector3 pos = transform.position+new Vector3(0,1.2f,0);
        GameObject trap=Instantiate(trapresource,pos,Quaternion.identity);
        Destroy(trap,0.5f);

        AudioClip trapsound=Instantiate(trapsoundresource) as AudioClip;
        AudioSource.PlayClipAtPoint(trapsound,pos);
        ScoreManager.AddTrap();


        other.transform.SendMessage("SetDamage",damage);
    }
}
