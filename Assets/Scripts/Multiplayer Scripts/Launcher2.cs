using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime; //*
using UnityEngine.SceneManagement; //*
using TMPro;

public class Launcher2 : MonoBehaviourPunCallbacks
{
    public GameObject lobbyPanel; //*
    public GameObject roomPanel; //*
    public GameObject scorePanel; //*


    public TMP_InputField createInput;
    public TMP_InputField joinInput;

    //public TMPnputField createInput;
    //public InputField joinInput;
    public Text error;

    public Text roomName; //*
    public Text playerCount; //*

    public GameObject playerListing; //*
    public Transform playerListContent; //*

    public GameObject scorePlayerListing;
    public Transform scorePlayerListContent;

    public Button startButton; //*
    //public Button settingsButton;

    //public GameObject readyButton;
    public Transform buttonOrganizer;

    private void Awake()
    {
        //PlayerPrefs.SetString("SceneName", null);
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void Start()
    {
        //Debug.Log(PlayerPrefs.GetString("SceneName"));
        //if (PlayerPrefs.GetString("SceneName") != "Grass_Level_1")
        //{
        //    OnFinishedGame();
        //}
        //else
        //{
            
            lobbyPanel.SetActive(true); //*
            roomPanel.SetActive(false); //*
            scorePanel.SetActive(false);

        //}
        


        
    }

    



    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(createInput.text))
            return;
        PhotonNetwork.CreateRoom(createInput.text);
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
        PhotonNetwork.AutomaticallySyncScene = true;

    }

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false); //*
        scorePanel.SetActive(false);
        roomPanel.SetActive(true); //*

       
        roomName.text = PhotonNetwork.CurrentRoom.Name;

        Player[] players = PhotonNetwork.PlayerList; //*

        playerCount.text = "" + players.Length;

        for (int i = 0; i < players.Length; i++) //*
        {
            Instantiate(playerListing, playerListContent).GetComponent<PlayerListing>().SetPlayerInfo(players[i]);

            if (i == 0)
            {
                startButton.interactable = true;
                //settingsButton.interactable = true;
            }
            else
            {
                startButton.interactable = false;
                //settingsButton.interactable = false;
            }
        }

        //Instantiate(readyButton, buttonOrganizer).GetComponent<ReadyButton>().SetCurrentPlayer(playerListContent.gameObject);

    }


    public void OnFinishedGame()
    {
        //SceneManager.LoadScene("Menu");
        lobbyPanel.SetActive(false); //*
        roomPanel.SetActive(false); //*
        scorePanel.SetActive(true);

        Player[] players = PhotonNetwork.PlayerList; //*


        playerCount.text = "" + players.Length;

        for (int i = 0; i < players.Length; i++)
        {
            //players[i].CustomProperties.Add(255, SceneManager.GetActiveScene());
            //if (players[i].CustomProperties.Add(255, SceneManager.GetActiveScene()) == SceneManager.sceneCount);
            Instantiate(scorePlayerListing, scorePlayerListContent).GetComponent<PlayerListing>().SetPlayerScore(players[i]);
        }

    }


    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        error.text = message;
        Debug.Log("Error creating room! " + message);
    }

    public void OnClickLeaveRoom() //*
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom() //*
    {
        SceneManager.LoadScene("Loading");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) //*
    {
        Instantiate(playerListing, playerListContent).GetComponent<PlayerListing>().SetPlayerInfo(newPlayer);
    }

    public void OnClickStartGame() //*
    {
        PhotonNetwork.LoadLevel("Grass_Level_1");

    }

    

}
