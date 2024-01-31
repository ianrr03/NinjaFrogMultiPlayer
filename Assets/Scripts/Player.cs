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
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        //Le damos velocidad pero tambien en el eje y, porque si no se quedaria parado
        rig.velocity = (transform.right * speed * Input.GetAxis("Horizontal")) + (transform.up * rig.velocity.y);

        if (rig.velocity.x > 0.1f)
        {//Cambiamos la imagen de movimiento

            GetComponent<SpriteRenderer>().flipX = false;
        }


        else if (rig.velocity.x < 0.1f)
            GetComponent<SpriteRenderer>().flipX = true;
           

        if (Input.GetButtonDown("Jump")) //Añadimos el salto
        {
            rig.AddForce(transform.up * jumpForce);

        }
        //Añadimos la animacion
         anim.SetFloat("velocityX", Mathf.Abs(rig.velocity.x));
         anim.SetFloat("velocityY", Mathf.Abs(rig.velocity.y));

    }
}
