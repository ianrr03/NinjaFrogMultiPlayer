using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Librerias de Photon
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //La instanciacion la hace Photon
        //Ojo el nombre lo busca en una carpeta que se llama Resources
        // Y es ahi donde tenemos que meter nuestros prefabs
        if (PhotonNetwork.IsMasterClient) 
            PhotonNetwork.Instantiate("Frog", new Vector3(-3, -3, 0) , Quaternion.identity);
        else
            PhotonNetwork.Instantiate("VirtualGuyPrefab", new Vector3(51, -3, 0), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
