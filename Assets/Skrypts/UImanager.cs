using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public List<GameObject> players;

    

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
    }
   public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is over");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
