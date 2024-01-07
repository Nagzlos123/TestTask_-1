using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float maneueverability;
    public float endurence;

    public Color leadColor;
    public Color noLeadColor;

    [SerializeField] private PlayerDataSet playerData;
    [SerializeField] private GameObject thisGameObject;
     public bool isSetToLead = false;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    }
}
