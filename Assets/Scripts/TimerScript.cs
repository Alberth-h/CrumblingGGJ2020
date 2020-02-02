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

    public GameObject fire;
    public GameObject water;
    public GameObject timon;
    public GameObject proa;
    public GameObject valla;
    public GameObject valla2;


    // Start is called before the first frame update
    void Start()
    {
        fire = GameObject.Find("FireBarrel");
        fire.SetActive(false);

        water = GameObject.Find("WaterHole");
        water.SetActive(false);

        timon = GameObject.Find("rueda");
        timon.transform.Rotate(0, 0, 0);
        timon.transform.position = new Vector3(0, 3, 12);

        proa = GameObject.Find("FireProa");
        proa.SetActive(false);

        valla = GameObject.Find("/Boat/Fences/Fence06");

        valla = GameObject.Find("/Boat/Fences/Fence09");


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
                    fire.SetActive(true);
                    break;
                case 1:
                    Debug.Log("Hoyo en el barco");
                    water.SetActive(true);
                    break;
                case 2:
                    Debug.Log("Timon caido");
                    timon.transform.Rotate(0, 90, -91);
                    timon.transform.position = new Vector3(0, 1.7f, 10);
                    break;
                case 3:
                    Debug.Log("Fuego en la proa");
                    proa.SetActive(true);
                    break;
                case 4:
                    Debug.Log("valla caida");
                    valla.transform.Rotate(40, 20, 0);
                    
                    break;
                case 5:
                    Debug.Log("valla caida dos");
                    valla.transform.Rotate(40, 20, 0);
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
