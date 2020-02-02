using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemadePuntaje : MonoBehaviour
{
    public static int ScoreValue = 0;
  
    public Text TextScore;

    // Start is called before the first frame update
    void Start()
    {
        TextScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        TextScore.text = "SCORE: " + ScoreValue;

        
    }
}
