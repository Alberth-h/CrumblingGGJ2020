using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvGene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int numerorandom = Random.Range(0, 4);
        Debug.Log(numerorandom);
    }
}
