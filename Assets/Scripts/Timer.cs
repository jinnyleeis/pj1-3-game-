using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerTxt;
    public float time=0;
    private float selectCountdown;


    void Start() {
        selectCountdown = time;
    }

    void Update() {
        if(Mathf.Floor(selectCountdown) <= 0) {
            timerTxt.text = "TIME OVER:".ToString();
         
        } else {
            selectCountdown -= Time.deltaTime;
            timerTxt.text = Mathf.Floor(selectCountdown).ToString();
        }
    }
}