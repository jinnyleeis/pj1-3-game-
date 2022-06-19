using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 
public class Resource : MonoBehaviour
{
    TextMeshProUGUI resourceText;
    private int resource;
    // Start is called before the first frame update
    void Start()
    {
        resourceText = GetComponent<TextMeshProUGUI>();
        resource = 500;
    }
 
    // Update is called once per frame
    void Update()
    {
        resourceText.text = resource.ToString();
    }
 
    public int GetResource()
    {
        return resource;
    }
 
    public void AddResource(int addition)
    {
        resource += addition;
    }
 
}
