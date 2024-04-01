using JetBrains.Annotations;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField]    float speed = 3.0f;
    [SerializeField]    Rigidbody2D rig;
    [SerializeField]    int jumpForce = 20;
    [SerializeField]    Animator anim;
    [SerializeField]
    private int puntos = 0;
    public TMP_Text puntuacionJugadorFrog;
    public TMP_Text puntuacionJugadorVirtualGuy;
    private string textoPuntuacion;
    [SerializeField]  GameObject FresaFruit;
    void Start()
    {
        if (GetComponent<PhotonView>().IsMine)
        { //Si no es mio este script


            rig = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            //Ojo las camaras no se sincronizan
            Camera.main.transform.SetParent(transform);
            Camera.main.transform.position = transform.position + (Vector3.up) + transform.forward * -10;

        }
        
    }

    
    void Update()
    {
        //Le damos velocidad pero tambien en el eje y, porque si no se quedaria parado
        
        




        if (GetComponent<PhotonView>().IsMine) 
        {
            rig.velocity = (transform.right * speed * Input.GetAxis("Horizontal")) + (transform.up * rig.velocity.y);

            if (rig.velocity.x > 0.1f && GetComponent<SpriteRenderer>().flipX)
            //Cambiamos la imagen de movimiento
                GetComponent<PhotonView>().RPC("RotateSprite", RpcTarget.All, false);
                //GetComponent<SpriteRenderer>().flipX = false;
            else if (rig.velocity.x <-0.1f &&! GetComponent<SpriteRenderer>().flipX)
                GetComponent<PhotonView>().RPC("RotateSprite", RpcTarget.All, true);//rotar el sprite
            //GetComponent<SpriteRenderer>().flipX = true;


            if (Input.GetButtonDown("Jump")) //Añadimos el salto
            {
                rig.AddForce(transform.up * jumpForce);

            }
            //Añadimos la animacion
            anim.SetFloat("velocityX", Mathf.Abs(rig.velocity.x));
            anim.SetFloat("velocityY", Mathf.Abs(rig.velocity.y));

        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Si el personaje colisiona con una fruta
        if (other.gameObject.CompareTag("Fruit"))
        {
            //Se destruye la fruta
            Destroy(other.gameObject); 

            //Se aumenta la puntuación en 10 puntos por fruta recogida
            puntos += 1;

            Debug.Log("Puntos jugador " + gameObject.name + ": " + puntos);
            //Se actualiza el cuadro de texto con la nueva puntuación
            //ActualizaTextoPuntuacion();

            //Se indica al GameManager que vuelva a instanciar una nueva fruta
            GameObject.Find("GameManager").GetComponent<GameManager>().NewFruit();

        }
    }

    //[PunRPC]
    //private void ActualizaTextoPuntuacion()
    //{
    //    if (GetComponent<PhotonView>().IsMine)//Nos aseguramos de actuar solo sobre nuestros propios componentes/atributos
    //    {
    //        //Asigna a cada jugador el cuadro de texto del canvas que le corresponda para mostrar su puntuación
    //        //Utilizo el identificador ActorNumber para saber qué jugador soy
    //        int playerNumber = PhotonNetwork.LocalPlayer.ActorNumber;

    //        //Utiliza el cuadro de texto adecuado según quién sea el jugador
    //        switch (playerNumber)
    //        {
    //            case 1: //Si es el jugador 1
    //                textoPuntuacion = "Jugador 1\n" + puntos.ToString() + " puntos";
    //                puntuacionJugadorFrog.text = textoPuntuacion;//Actualizo el texto en local
    //                //Y luego actualizo el texto en red para que cambie también en el otro jugador (usando RPC)
    //                photonView.RPC(nameof(CambiartextoPuntuacionRed), RpcTarget.AllBuffered, 1, textoPuntuacion);
    //                break;

    //            case 2: //Si es el jugador 2
    //                textoPuntuacion = "Jugador 2\n" + puntos.ToString() + " puntos";
    //                puntuacionJugadorVirtualGuy.text = textoPuntuacion;//Actualizo el texto en local
    //                //Y luego actualizo el texto en red para que cambie también en el otro jugador (usando RPC)
    //                photonView.RPC(nameof(CambiartextoPuntuacionRed), RpcTarget.AllBuffered, 2, textoPuntuacion);
    //                break;
    //        }
    //    }

    //}

    [PunRPC]
    private void CambiartextoPuntuacionRed(int jugador, string texto)
    {
        //Se recibe como primer parámetro el número de jugador al que hay que cambiar la puntuación y como segundo parámetro el texto a mostrar
        if (jugador == 1 && puntuacionJugadorFrog)
        {
            puntuacionJugadorFrog.text = texto;
        }
        if (jugador == 2 && puntuacionJugadorVirtualGuy) //Nota: en los if he añadido la segunda condición para evitar un error que aparecía en consola de objetos nulos
        {
            puntuacionJugadorVirtualGuy.text = texto;
        }
    }
    [PunRPC] //este metodo estaba en el update y tiene que estar fuera porque es un metodo
    void RotateSprite(bool rotate)
    {
        GetComponent<SpriteRenderer>().flipX = rotate;
    }
}
