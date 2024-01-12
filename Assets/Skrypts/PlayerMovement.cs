using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Camera cam;
     private NavMeshAgent agent;
    [HideInInspector]
    public Transform destination = null;

    
    private float stopDestination = 3f;
    private Player player;



    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GetComponent<Player>();
       
    
        

    }


    // Update is called once per frame
    void Update()
    {
        if (destination != null && player.isSetToLead == false)
        {
            float distance = Vector3.Distance(transform.position, destination.position);

            if(distance < stopDestination)
            {
                StopAgent();
            }
            else
            {
                SetTarget();
            }

        }
        else 
        {
            MoveTo();
            
        }

     

      


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
                    agent.isStopped = false;
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

 



    private void StopAgent()
    {
        agent.isStopped = true;
        //Debug.Log("Agent was stopped!");
    }

    public void SetTarget()
    {
        //seting destination point for no lead players
       agent.isStopped = false;
       agent.SetDestination(destination.position); 
    }

    public void SetAgentSpeed()
    {
        agent.speed = player.speed;
    }

    public void SetAgentAngularSpeed()
    {
        agent.angularSpeed = player.maneuverability;
    }
}
