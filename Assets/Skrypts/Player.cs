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
    bool isSetToLead = false;
   

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
        //GameObject thisGameObject = this.GetComponent<GameObject>();
        thisGameObject.GetComponent<Renderer>().material.color = noLeadColor;
        isSetToLead = false;

    }

    public void SetLeadPlayer()
    {

        //GameObject thisGameObject = this.GetComponent<GameObject>();
        thisGameObject.GetComponent<Renderer>().material.color = leadColor;
        //GameObject.Find("Cube").GetComponent<Renderer>().material.color = new Color(0, 204, 102);
        isSetToLead = true;
    }

    public void GetDataSet()
    {

    }
}
