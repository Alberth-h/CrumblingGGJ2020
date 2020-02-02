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
    public int IsRunning=1;
    public int numerorandom;


    // Start is called before the first frame update
    void Start()
    {
        numerorandom = UnityEngine.Random.Range(0, 6);
        Debug.Log(numerorandom);
        timer = GetComponent<Image>();
        TimeLeft = MaxTime;

        StartCoroutine(NumberGen());
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

    IEnumerator NumberGen()
    {
        while (true)
        {  IsRunning = 0;
           
            yield return new WaitForSeconds(2);
            

            switch (numerorandom)
            {
                case 0:
                    Debug.Log("Barril incendiado");
                    break;
                case 1:
                    Debug.Log("Hoyo en el barco");
                    break;
                case 2:
                    Debug.Log("Timon caido");
                    break;
                case 3:
                    Debug.Log("Fuego en la proa");
                    break;
                case 4:
                    Debug.Log("valla caida");
                    break;
                case 5:
                    Debug.Log("valla caida dos");
                    break;
                default:
                    break;

            }

            numerorandom = UnityEngine.Random.Range(0, 6);
            Debug.Log(numerorandom);

            IsRunning = 1;
}
    }

    //Put this in Start()


}
