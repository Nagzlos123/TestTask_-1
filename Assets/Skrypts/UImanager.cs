using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public List<GameObject> players;
    public GameObject leadPlayer;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ButtonCliked( GameObject playerCharakter)
    {

        foreach (var player in players)
        {
            player.GetComponent<Player>().ResetPlayer();
        }

        var currentPlayer = playerCharakter.GetComponent<Player>();
        currentPlayer.SetLeadPlayer();
        leadPlayer = playerCharakter;
    }
   public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is over");
    }


    private void SetMovingDestination()
    {
        foreach (var player in players)
        {
            if (player.GetComponent<Player>().isSetToLead == false)
            {
                player.GetComponent<PlayerMovement>().destination = leadPlayer.transform;
            }
            else
            {
                player.GetComponent<PlayerMovement>().destination = null;
            }
        }

    }



    // Update is called once per frame
    void Update()
    {
       if(leadPlayer != null)
        {
            SetMovingDestination();
        }
       
    }
}
