using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

RectTransform hpBar;
Rect rect;

    // Start is called before the first frame update
    void Start()
    {
        var back=transform.Find("Background").GetComponent<RectTransform>();
        rect =back.rect;

        hpBar=transform.Find("Fill Area").GetComponent<RectTransform>();
        hpBar.sizeDelta=new Vector2(rect.width,rect.height);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.parent==null) return;

        int dir =(transform.parent.localScale.x>0)?1:-1;
        Vector3 scale = transform.localScale;

        scale.x=Mathf.Abs(scale.x)*dir;
        transform.localScale=scale;  
        
    }

    void SetHP(float hp)
    {
        hpBar.sizeDelta=new Vector2(rect.width*hp,rect.height);
    }
}
