using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    public GameObject player;
    //public float xAngle;
    //private float Anglex;
    // Start is called before the first frame update
    void Start()
    {
    }

    [SerializeField]
    Color rayColor = Color.red;
    [SerializeField, Range(0f, 20f)]
    public float rayDistance;

    public RaycastHit TheHit;

    // Update is called once per frame
    void Update()
    {

        if (CloseObject)
        {
            Debug.Log("Estás tocando algo.");
        }
    }

    bool CloseObject
    {
        get => Physics.Raycast(player.transform.position, new Vector3(rayDistance, 0)); 
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDistance);
    }
}
