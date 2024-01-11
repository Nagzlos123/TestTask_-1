using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float maneuverability;
    public float endurence;

    public Color leadColor;
    public Color noLeadColor;

    public PlayerDataSet playerData;
    [SerializeField] private GameObject thisGameObject;
     public bool isSetToLead = false;
    private PlayerMovement movement;

    [SerializeField] private float counterTask1 = 30f;
    [SerializeField] private float counterTask2 = 20f;
    [SerializeField] private bool chooseTask;
    [SerializeField] private float timer;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        timer = 0;
        chooseTask = false;
    }



    // Update is called once per frame
    void Update()
    {
        GetDataSet();

        if (UImanager.isButtonClicked == true)
        {
            EndurenceTimer();
        }
            
    }

    public void ResetPlayer()
    {
        
        thisGameObject.GetComponent<Renderer>().material.color = noLeadColor;
        isSetToLead = false;

    }

    public void SetLeadPlayer()
    {

        
        thisGameObject.GetComponent<Renderer>().material.color = leadColor;
        isSetToLead = true;
    }

    public void GetDataSet()
    {
        if (playerData != null)
        {
            PlayerDataSet currentDataSet = playerData;
            speed = currentDataSet.speed;
            maneuverability = currentDataSet.maneuverability;
            endurence = currentDataSet.endurence;
            counterTask1 = currentDataSet.endurence;

            thisGameObject.GetComponent<PlayerMovement>().SetAgentSpeed();
            thisGameObject.GetComponent<PlayerMovement>().SetAgentAngularSpeed();

        }
    }
    public void EndurenceTimer()
    {
        counterTask1 = playerData.endurence;
        timer += Time.deltaTime;

        if (chooseTask == false && timer >= counterTask1)
        {
            timer -= counterTask1;
            chooseTask = true;
            movement.enabled = false;

                 
        }
        else if (chooseTask == true && timer >= counterTask2)
        {
            timer -= counterTask2;
            chooseTask = false;
            movement.enabled = true;
        }
    }
}
