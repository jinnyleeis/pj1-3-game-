using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGraphic_ : MonoBehaviour
{
    public GameObject[] players;
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public GameObject Bullet;
    Transform gunPoint;
    private float hp=Settings.HP;
    bool isDead=false;
    

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

       gunPoint=transform.Find("GunPoint");


        //attack
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("attack started!");

        }
        //Jump
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            animator.SetBool("Jumping", true);
        }
            

        //Stop Speed
        if(Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        //Direction Sprite
        if (Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        //Animation
        if (Mathf.Abs(rigid.velocity.x) < 0.01 )
            animator.SetBool("Moving", false);
        else
            animator.SetBool("Moving", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move By Keycontrol
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed) // Right Max Speed
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1)) // Left Max Speed
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }

        //Landing Platform
        Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));

            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 2, LayerMask.GetMask("Platform"));

            if (rayHit.collider != null)
            {
                if (rayHit.distance < 1.0f)
                    animator.SetBool("Jumping", false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            FireGun();

        }

      if(isDead) return;
      SetHP();

      //SetAnimation();  
    }

    private void OnLevelWasLoaded(int level)
    {
        FindStartPos();
        players= GameObject.FindGameObjectsWithTag("Player");
        if(players.Length>1)
        {
            Destroy(players[0]);
        }
    }

     void FindStartPos()
     {
         transform.position=GameObject.FindWithTag("StartPos").transform.position;
     }


     
    




     void FireGun()
     {


        Debug.Log("BOOMERANG");
         Quaternion rotation = transform.rotation;
         //if(transform.localScale.x<0){
          
        // }

         Instantiate(Bullet,gunPoint.position,gunPoint.rotation);
         
     }
     //adding hp by getting energy 
     void AddHP()
     {
         hp+=Settings.HP_ADD;
        //hp=Mathf.Clamp(hp,0,Settings.PlayerHP);

     }

     void SetHP()
     {
         //hp-=Settings.HP_DEC;
         //ScoreManager.hp=hp;

         if(hp<0)
         {
             isDead=true;
         }
     }

     void SetDamage(float damage)
     {
         if(!isDead)
         {
             hp-=damage;
         }
     }
    
    void SetPlayerDead()
    {
        Destroy(gameObject);
    }
   
}
