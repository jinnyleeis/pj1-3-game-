using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadlevel : MonoBehaviour
{
   

public int iLevelToLoad;
public string sLevelToLoad;

public bool useIntegerToLoadLevel=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void  OnCollisionEnter2D(Collision2D collision)
     {
        GameObject collisionGameObject = collision.gameObject;
        Debug.Log("fit collition");

        if(collisionGameObject.name=="Player")
        {
             Debug.Log("fit collition2");

            LoadScene();
        }
    }


    void LoadScene()
    {

        if(useIntegerToLoadLevel)
        {

            SceneManager.LoadScene(iLevelToLoad);

        }
        else
        {
            SceneManager.LoadScene(sLevelToLoad);
        }


    }
}
