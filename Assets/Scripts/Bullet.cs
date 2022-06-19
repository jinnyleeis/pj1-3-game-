using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

   public float speed = 10;
   public GameObject expresource;
   public AudioClip sndClip;
    // Start is called before the first frame update

    void Awake() 
    {
        //player완 충돌 막음 
        LayerMask player =LayerMask.NameToLayer("Player");
        Physics2D.IgnoreLayerCollision(player,player); //플레이어간의 충돌은 무시해라

        Destroy(gameObject, 2f);
    }

    void Start()
    {
        AudioSource.PlayClipAtPoint(sndClip,transform.position);
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right*speed*Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
       // Instantiate(exp,transform.position,transform.rotation);
        Debug.Log("explostions");
       // exp.transform.localScale=new Vector3(0.3f,0.3f,0.3f);
       // exp.transform.position=transform.position;
       GameObject exp=Instantiate(expresource,transform.position,transform.rotation) as GameObject;

        Destroy(exp,0.5f);
    }

    

    
}
