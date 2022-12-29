using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseMovement : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    private string groundTag = "Ground";

    private NavMeshAgent agent;

    private RaycastHit hit;

    // Called when a script is enabled
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Called once every frame
    void Update()
    {
        //using GetMouseButton instead of GetMouseButtonDown to continuosly adjust player's movement
        if (Input.GetMouseButton(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag(groundTag))
                {
                    agent.SetDestination(hit.point);
                }
            }
        }
    }
}