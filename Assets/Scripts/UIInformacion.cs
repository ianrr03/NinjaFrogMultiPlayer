using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class UIInformacion : MonoBehaviourPunCallbacks, IPunObservable//hacemos que sea observable
{
    //variables
    public TMP_Text informacion; //texto de informacion banner
    public TMP_Text puntuacion;
    public int playerNum; // Numero de jugador
    void Start()
    {
        StartCoroutine("SetPlayerOrEnemy"); //poco a poco se va ejecutando en segundo plano
    }

    IEnumerator SetPlayerOrEnemy() //Ponemos si somos jugador o enemigo
    {
        yield return new WaitForSeconds(3); //tarda en ejecutarse 3 segundos por eso esta en el start
        if (photonView.IsMine) //El photonWiew es mio
        {
            informacion.text = "Yo soy el jugador";
            puntuacion.text = "Ha puntuado el jugador";
        }

        if (!photonView.IsMine) //sin No
        {
            informacion.text = "Soy el enemigo";
            puntuacion.text = "Ha puntuado el enemigo";
        } 
    }//SetPlayerOrEnemy


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // throw new System.NotImplementedException();
    }//OnPhotonSerializeView

}//UIInformacion