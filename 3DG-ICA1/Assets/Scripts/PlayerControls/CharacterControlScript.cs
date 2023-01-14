using UnityEngine;
using UnityEngine.AI;
public class CharacterControlScript : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent player;
    public Animator playerAnimator;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;

            if(Physics.Raycast(ray, out hitPoint))
            {
                player.SetDestination(hitPoint.point);
            }
        }

        if(player.velocity != Vector3.zero)
        {
            playerAnimator.SetBool("isWalking", true);
        }
        else if(player.velocity == Vector3.zero)
        {
            playerAnimator.SetBool("isWalking", false);
        }
    }
}
