using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poja : MonoBehaviour
{
    float speed;
    int damage=10;
    public GameObject pojaresource1;
    public AudioClip pojasoundresource;
    public GameObject Bullet1;

    void  Awake() {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.right*speed*Time.deltaTime);
        
    }

    void  OnCollisionEnter2D(Collision2D other) {
        
        switch (other.transform.tag)
        {
            case "Player":
            other.transform.SendMessage("SetDamage",damage);
             ScoreManager.AddTrap();

            
            DestroySelf();
            break;

            case "Bullet":
            Debug.Log("poja vs bullet");
            Destroy(gameObject);
            DestroySelf();
            break;
        }
    }
    
    void DestroySelf()
    {
        Vector3 pos = transform.position;
        GameObject spore=Instantiate(pojaresource1,transform.position,Quaternion.identity) as GameObject;
        AudioClip pojasound=Instantiate(pojasoundresource) as AudioClip;
        AudioSource.PlayClipAtPoint(pojasound,pos);
        Destroy(spore,0.5f);

       
    }

    public void SetSpeedAndDamage(float _speed, int _damage)
    {
        speed=_speed;
        damage=_damage;

        GetComponent<Rigidbody2D>().gravityScale=(speed==0)?1:0;
    }

}
