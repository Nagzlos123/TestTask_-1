using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private NavMeshAgent agent;
    [HideInInspector]
    public Transform destination = null;
    [SerializeField] private Player player;



    // Update is called once per frame
    void Update()
    {
        MoveTo();
        SetTarget();
    }

    public void MoveTo()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) // Solve the problem of Raycast interfering with UI components
        {

            Ray mouseInputRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(mouseInputRay, out raycastHit))
            {
                

                if (player.isSetToLead == true) //seting destination point for lead player
                {
                    agent.SetDestination(raycastHit.point);
                    destination = null;
                }
                else
                {
                    //SetTarget();
                }
            }

        }
    }

    public void SetTarget()
    {
        //seting destination point for no lead players
        if(destination != null)
        agent.SetDestination(destination.position);
    }
}
