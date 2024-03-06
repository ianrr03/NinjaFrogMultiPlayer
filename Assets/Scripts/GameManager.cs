using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Librerias de Photon
using Photon.Pun;
using JetBrains.Annotations;

public class GameManager : MonoBehaviour
{
    //public GameObject fresa; examen
    //private float rangoGeneracion = 9.0f; examen
    // Start is called before the first frame update
    void Start()
    {
        

        //float poxXgeneracion = Random.Range(-rangoGeneracion, rangoGeneracion); examen
        //float posZgeneracion = Random.Range(-rangoGeneracion, rangoGeneracion); examen
        //Vector3 posAleatoria = new Vector3(poxXgeneracion, 0, posZgeneracion); examen
        //La instanciacion la hace Photon
        //Ojo el nombre lo busca en una carpeta que se llama Resources
        // Y es ahi donde tenemos que meter nuestros prefabs
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("Frog", new Vector3(-3, -3, 0), Quaternion.identity);
            PhotonNetwork.Instantiate("Strawberry_0", new Vector3(29, 5, 0), Quaternion.identity); //no quiere instanciar la fresa
            Debug.Log("Has pasado por la fresa");
        }

        else
            PhotonNetwork.Instantiate("VirtualGuyPrefab", new Vector3(51, -3, 0), Quaternion.identity);
            PhotonNetwork.Instantiate("Strawberry_0", new Vector3(29, 5, 0), Quaternion.identity); //no quiere instanciar la fresa
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
