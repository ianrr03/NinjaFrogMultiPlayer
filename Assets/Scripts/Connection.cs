using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
//Librerias de Photon
using Photon.Pun;
using Photon.Realtime;

public class Connection : MonoBehaviourPunCallbacks
{
    
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //Nos conectamos con el parametro definido
        PhotonNetwork.AutomaticallySyncScene = true; // Activamos la sincronizacion de escena, necesario para el intercambio entre escenas
    }

    // Metodo para conectarse al master
    override

    public void OnConnectedToMaster()
    {
        print("Conectado al master !!!");

    }

    public void ButtonConnect() //Metodo de conexion con el master con el boton
    {
        RoomOptions options = new RoomOptions() { MaxPlayers = 4};
        PhotonNetwork.JoinOrCreateRoom("room1", options, TypedLobby.Default);
    }
    
    override

    public void OnJoinedRoom() //Metodo de conexion con una sala
    {
        Debug.Log("Conectado a la sala" + PhotonNetwork.CurrentRoom.Name);
        Debug.Log("Conectado a la sala" + PhotonNetwork.CurrentRoom.PlayerCount + " jugadores");
    }

    private void Update() //Metodo que controla si pasamos a la siguiente escena si somos mas de una persona
    {
        if(PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount > 1)
        {
            //Cargamos siguiente nivel es decir el gameplay
            PhotonNetwork.LoadLevel(1);
            Destroy(this);
        }
    }
    
}
