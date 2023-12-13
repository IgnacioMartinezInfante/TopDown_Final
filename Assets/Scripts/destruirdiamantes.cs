using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class destruirdiamantes : MonoBehaviour
{
    public AudioSource clip;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("jugador"))
        {
            contadordiamantes contardiamantes = FindObjectOfType<contadordiamantes>();
            if (contardiamantes != null)
            {
                contardiamantes.Increasecontardiamantes(); 
            }
            clip.Play();
            Destroy(gameObject);           
        }
    }
}
