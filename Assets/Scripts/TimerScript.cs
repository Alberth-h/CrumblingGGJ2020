using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    Image timer;

    

    public float TimeLeft ;
    public float MaxTime = 20f;
    float pipi = 0.3045f;
    public int IsRunning=1;
    public int numerorandom;

    public GameObject fire;
    public GameObject proa2;
    public GameObject timon;
    public GameObject proa;
    public GameObject valla;
    public GameObject valla2;


    // Start is called before the first frame update
    void Start()
    {
        fire = GameObject.Find("FireBarrel");
        fire.SetActive(false);

        proa2 = GameObject.Find("FireProa2");
        proa2.SetActive(false);

        timon = GameObject.Find("rueda");
        timon.transform.Rotate(0, 0, 0);
        timon.transform.position = new Vector3(0, 3, 12);

        proa = GameObject.Find("FireProa");
        proa.SetActive(false);

        valla = GameObject.Find("/Boat/Fences/Fence06");

        valla2 = GameObject.Find("/Boat/Fences/Fence09");


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
            TimeLeft -= Time.deltaTime ;
            TimeLeft += MovPlayer.additive;

            if (MovPlayer.additive == 1f)
            {
                timer.transform.Rotate(0, 0, pipi * 59f);
                Debug.Log("1 segundo");
            }
            else if (MovPlayer.additive == 0f)
            {
                timer.transform.Rotate(0, 0, -pipi);
            }
           // Debug.Log(TimeLeft);
            MovPlayer.additive = 0f;

        }

        if(TimeLeft<=0)
        {
           
            SceneManager.LoadScene(2);
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
                    fire.SetActive(true);
                    break;
                case 1:
                    Debug.Log("Hoyo en el barco");
                    proa2.SetActive(true);
                    break;
                case 2:
                    Debug.Log("Timon caido");
                    timon.transform.rotation = Quaternion.Euler(90f,0f,-94f);
                    timon.transform.position = new Vector3(0, 1.7f, 10);
                    break;
                case 3:
                    Debug.Log("Fuego en la proa");
                    proa.SetActive(true);
                    break;
                case 4:
                    Debug.Log("valla caida");
                    valla.transform.rotation = Quaternion.Euler(-60f, -67f, 222f);

                    break;
                case 5:
                    Debug.Log("valla caida dos");
                    valla2.transform.rotation = Quaternion.Euler(147f, 20f, -47f);
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
