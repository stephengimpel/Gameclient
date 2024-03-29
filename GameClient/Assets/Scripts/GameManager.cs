﻿using Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //TODO: Create namespace for player and import it
    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();

    public GameObject localPlayerPrefab;
    public GameObject playerPrefab;
    private void Awake() {
        if(instance == null) {
            instance = this;
        }
        else if(instance != null) {
            Debug.Log("Instance already exists, destroying object");
            Destroy(this);
        }
    }
    public void SpawnPlayer(int id, string username, Vector3 position, Quaternion rotation) {
        GameObject player;
        if(id == Client.instance.clientId) {
            player = Instantiate(localPlayerPrefab, position, rotation);
        } else {
            player = Instantiate(playerPrefab, position, rotation);
        }

        player.GetComponent<PlayerManager>().id = id;
        player.GetComponent<PlayerManager>().username = username;
        players.Add(id, player.GetComponent<PlayerManager>());
    }
}
