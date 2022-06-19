using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy1 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pojaresource;
    public GameObject Bullet1;
    Transform gunPoint1;
    int damage;
    float delay;
    float time;
    Vector3 pos;
    Transform target;//주인공
    int dir;//주인공의 위치
    public float delayTime=5.0f;
    public bool isDelay;
    void Start()
    {
        damage=10;
        delay=0.1f;
        pos=transform.position+new Vector3(0,1.5f,0);
    }

    // Update is called once per frame
    void Update()
    {

        gunPoint1=transform.Find("GunPoint1");
        if(isDelay==false){
            isDelay=true;
            FireGun();
            StartCoroutine(Waitone());
        }
        else{
            Debug.Log("poja not now");
        }
        
        if (target!=null&&Time.time-time>delay){

           

            MakeSpore();
            time=Time.time;
        }

        IEnumerator Waitone()
        {

            yield return new WaitForSeconds(5.0f);
            isDelay=false;
        }

        void MakeSpore()
        {
             
             

            Vector3 ballPos=pos;
            ballPos.x+=Random.Range(-2f,2f);

            dir=(transform.position.x>target.position.x)?-1:1;
            float torque=Random.Range(-5,10)*dir;
            //sporeball
            GameObject spore=Instantiate(pojaresource,transform.position,transform.rotation) as GameObject;
            //GameObject exp=Instantiate(expresource,transform.position,transform.rotation) as GameObject;
            spore.GetComponent<Rigidbody2D>().AddTorque(torque);
        }


        void  OnTriggerEnter2D(Collider2D other) {
            
            if(other.tag=="Bullet")
            {
                Debug.Log("bullet과 닿은 적");
                //target=other.transform;
                

            } }

        void OnTriggerExit2D(Collider2D other) {
             if(other.tag=="Player")
            {
                target=null;

            }
        }

        void FireGun()
     {


        Debug.Log("poja!!");
         Quaternion rotation = transform.rotation;
         //if(transform.localScale.x<0){
          
        // }

         Instantiate(Bullet1,gunPoint1.position,gunPoint1.rotation);
         
     }
    }
}
