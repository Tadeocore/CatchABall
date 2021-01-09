using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;


public class GestorPhoton : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        base.OnConnectedToMaster();

    }
    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("Lobby", new RoomOptions { MaxPlayers = 2 }, TypedLobby.Default);
        base.OnJoinedLobby();
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        //PhotonNetwork.Instantiate("Jugador", new Vector3(Random.Range(-7, 7)2));
    }
}
