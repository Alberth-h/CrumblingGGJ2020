using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    Image timer;
    float TimeLeft ;
    public float MaxTime = 20f;
    float pipi = 0.3045f;


    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Image>();
        TimeLeft = MaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
            timer.transform.Rotate(0, 0, -pipi); 
        }

        if(TimeLeft<=0)
        {
           
            SceneManager.LoadScene(1);
        }
    }
    
}
