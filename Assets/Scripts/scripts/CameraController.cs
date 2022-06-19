using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        this.player =GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos=this.player.transform.position;
        transform.position=new Vector2(transform.position.x,playerPos.y);
    }
}
