using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Update()
    {
        
    }
}
