using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UImanager : MonoBehaviour
{
    public List<GameObject> players;
    [HideInInspector]
    public GameObject leadPlayer;
    public PlayerDataSet[] playerDataSets;
    public int dataSetLength;
    public static bool isButtonClicked = false;

    [SerializeField] private TextMeshProUGUI speedDisplay;
    [SerializeField] private TextMeshProUGUI maneuverabilityDisplay;
    [SerializeField] private TextMeshProUGUI endurenceDisplay;
    // Start is called before the first frame update
    void Start()
    {
        dataSetLength = playerDataSets.Length - 1;
        AddRandomDataSetsToPlayers();
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
        isButtonClicked = true;
    }
   public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is over");
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LeadPlayerPanelInfo()
    {
        PlayerDataSet currentDataSet = leadPlayer.GetComponent<Player>().playerData;
        speedDisplay.text = currentDataSet.speed.ToString();
        maneuverabilityDisplay.text = currentDataSet.maneuverability.ToString();
        endurenceDisplay.text = currentDataSet.endurence.ToString();
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

    private void AddRandomDataSetsToPlayers()
    {
        foreach (var player in players)
        {
            var randomDataSet = Random.Range(0, dataSetLength);

            player.GetComponent<Player>().playerData = playerDataSets[randomDataSet];
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
