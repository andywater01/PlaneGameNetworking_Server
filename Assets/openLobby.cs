using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openLobby : MonoBehaviour
{
    public GameObject lobby;
    public GameObject GameLobby;
    public void openTheLobby()
    {
        lobby.SetActive(false);
        GameLobby.SetActive(true);
    }
}
