using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovPlayer : MonoBehaviour
{
    public GameObject timon ;

    public static float additive = 0f;

    public float gravity = 9.8f;

    public float horizontalMove;
    public float verticalMove;
    public CharacterController player;
    public Animation walk;

    public GameObject screwdriver;
    public GameObject extinguisher;
    public GameObject hammer;

    private Vector3 playerInput;

    public float playerSpeed;
    private Vector3 movePlayer;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    [SerializeField]
    Transform timonPoint;

    // Start is called before the first frame update
    void Start()
    {
        timon = GameObject.Find("rueda");

        player = GetComponent<CharacterController>();
        screwdriver.gameObject.SetActive(false);
        extinguisher.gameObject.SetActive(false);
        hammer.gameObject.SetActive(false);
    }

    [SerializeField]
    Color rayColor = Color.red;
    [SerializeField, Range(0f, 20f)]
    public float rayDistance;
    [SerializeField]
    LayerMask targetLayer;

    RaycastHit TheHit;

    private bool ObjectBool; 
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            screwdriver.gameObject.SetActive(true);
            hammer.gameObject.SetActive(false);
            extinguisher.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            hammer.gameObject.SetActive(true);
            screwdriver.gameObject.SetActive(false);
            extinguisher.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            extinguisher.gameObject.SetActive(true);
            screwdriver.gameObject.SetActive(false);
            hammer.gameObject.SetActive(false);
        }


        camDirection();

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        if (CloseObject)
        {
           // Debug.Log(TheHit.collider.name);
        }


    }
    private void FixedUpdate()
    {
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        player.transform.LookAt(player.transform.position + movePlayer);
        SetGravity();
        player.Move(movePlayer * playerSpeed);
       /* if(CloseObject == true)
        {
            if(screwdriver.gameObject.activeSelf)
            {

            }
        }*/

        if(hit)
        {
            //Debug.Log("golpeado");
            if(extinguisher.activeSelf)
            {
                if (TheHit.collider.CompareTag("fire"))
                {
                    //Destroy(TheHit.collider.gameObject);
                    TheHit.collider.gameObject.SetActive(false);
                    SistemadePuntaje.ScoreValue += 80;
                    additive = 1f;
                }
                
            }
            if (screwdriver.activeSelf)
            {
                if (TheHit.collider.CompareTag("timon"))
                {
                    if (TheHit.collider.transform.position != timonPoint.position)
                    {
                        SistemadePuntaje.ScoreValue += 80;
                        additive = 1f;
                    }
                    TheHit.collider.transform.position = timonPoint.position;
                    
                }
    
            }
            if (hammer.activeSelf)
            {
                if (TheHit.collider.CompareTag("valla"))
                {
                    if (TheHit.collider.transform.rotation != Quaternion.Euler(-88f, -56f, 90f))
                    {
                        SistemadePuntaje.ScoreValue += 80;
                        additive = 1f;
                    }
                    TheHit.collider.transform.rotation = Quaternion.Euler(-88f, -56f, 90f);
                    
                    
                }
                if (TheHit.collider.CompareTag("valla2"))
                {
                    if (TheHit.collider.transform.rotation != Quaternion.Euler(-90f, 0f, -89f))
                    {
                        SistemadePuntaje.ScoreValue += 80;
                        additive = 1f;
                    }
                    TheHit.collider.transform.rotation = Quaternion.Euler(-90f, 0f, -89f);
                    
                }
            }
        }
    }

    public bool hit
    {

        get => Physics.Raycast(transform.position, transform.forward, out TheHit, rayDistance, targetLayer);
    }

    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    void SetGravity()
    {
        movePlayer.y = -gravity * Time.deltaTime;
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