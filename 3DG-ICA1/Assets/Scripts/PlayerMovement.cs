using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{   
    Rigidbody rb;
    //the movementSpeed and jumpForce values are in order to read and understand the code below more properly.
    //plus the serialization allows future adjustments through unity, not making it public so the other code files cannot access them.
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    //For mouse controls
    public Camera camera;

    private RaycastHit hit;

    private NavMeshAgent agent;

    private string groundTag = "Ground";
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //For mouse controls
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //For mouse controls
        if(Input.GetMouseButton(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.collider.CompareTag(groundTag))
                {
                    agent.SetDestination(hit.point);
                }
            }
        }

        //new keyboard movement controls that better simulates the player character's velocity during movement
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        //jumping  - the rb.velocity.x and .z are for the player to not immediately stop moving after moving, and simulating momentum.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
        
        /* //older test movement
        if(Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(0, 0, 5f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(5f, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-5f, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(0, 0, -5f);
        }
        */
        
    }
}
