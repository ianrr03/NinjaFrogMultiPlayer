using JetBrains.Annotations;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed = 3.0f;
    [SerializeField]
    Rigidbody2D rig;
    [SerializeField]
    int jumpForce = 20;
    [SerializeField]
    Animator anim;
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
        [PunRPC]
        void RotateSprite(bool rotate)
        {
            GetComponent<SpriteRenderer>().flipX = rotate;
        }


        if (GetComponent<PhotonView>().IsMine) 
        {
            rig.velocity = (transform.right * speed * Input.GetAxis("Horizontal")) + (transform.up * rig.velocity.y);

            if (rig.velocity.x > 0.1f && GetComponent<SpriteRenderer>().flipX)
            //Cambiamos la imagen de movimiento
                GetComponent<PhotonView>().RPC("RotateSprite", RpcTarget.All, false);
                //GetComponent<SpriteRenderer>().flipX = false;
            else if (rig.velocity.x < 0.1f && GetComponent<SpriteRenderer>().flipX)
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
}
