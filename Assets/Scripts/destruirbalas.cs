using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruirbalas : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("jugador"))
        {
            contadorbalas contarbalas = FindObjectOfType<contadorbalas>();
            if (contarbalas != null)
            {
                contarbalas.Increasecontarbalas(); 
            }

            Destroy(gameObject); 
        }
    }
}
