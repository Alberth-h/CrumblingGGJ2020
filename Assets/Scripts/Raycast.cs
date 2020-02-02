using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    [SerializeField]
    Color rayColor = Color.red;
    [SerializeField, Range(0f, 20f)]
    public float rayDistance;

    RaycastHit TheHit;

    // Update is called once per frame
    void Update()
    {

        if (CloseObject)
        {
            Debug.Log(TheHit.collider.name);
        }
    }


    bool CloseObject
    {

        get => Physics.Raycast(player.transform.position, new Vector3(rayDistance, 0), out TheHit);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDistance);
    }
}
