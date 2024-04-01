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

    //Array con los posibles puntos de spwan de las frutas
    public GameObject[] fruits;
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
            
            
        }

        else
        {
            PhotonNetwork.Instantiate("VirtualGuyPrefab", new Vector3(51, -3, 0), Quaternion.identity);
        }
            
        NewFruit();//Instancia la primera fruta del juego 
    }

    public void NewFruit()
    {
        //Espera 5 segundos y llama al método que instancia una fruta          
        Invoke("InstantiateFruit", 5.0f);
    }

    private void InstantiateFruit()
    {
        if (PhotonNetwork.IsMasterClient) //Hay que ponerlo para que solo instancie la fruta el jugador Master. Si no, cada jugador que hubiera instanciaría una
        {
            //Instancia una fruta en la posición de uno de los swpanpoints elegido aleatoriamente (de cero hasta el número de spawn points que haya)
            int spawnPointFruit = Random.Range(0, fruits.Length);
            PhotonNetwork.Instantiate("Strawberry_0", fruits[spawnPointFruit].transform.position, Quaternion.identity);
        }

    }
    
}
