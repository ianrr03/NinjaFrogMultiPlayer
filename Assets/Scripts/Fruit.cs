using ParrelSync.NonCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private GameObject efecto;

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Instantiate(efecto, transform.position, Quaternion.identity);
    //        Destroy(gameObject);
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    //Si el personaje colisiona con una fruta
    //    if (other.gameObject.CompareTag("Fruit"))
    //    {
    //        //Se destruye la fruta
    //        Destroy(this.gameObject);

    //        //Se aumenta la puntuación en 10 puntos por fruta recogida
    //        puntos += 1;

    //        Debug.Log("Puntos jugador " + gameObject.name + ": " + puntos);
    //        //Se actualiza el cuadro de texto con la nueva puntuación
    //        //ActualizaTextoPuntuacion();

    //        //Se indica al GameManager que vuelva a instanciar una nueva fruta
    //        GameObject.Find("GameManager").GetComponent<GameManager>().NewFruit();

    //    }
    //}
}
