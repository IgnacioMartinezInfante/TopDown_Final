using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bala : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("jugador"))
        {
            vidajugador sacarvidaporbala = GameObject.Find("jugador").GetComponent<vidajugador>();
            sacarvidaporbala.reducirvidabalatirador();
        }
        Impactoobjeto();
    }

    void Impactoobjeto()
    {
        Destroy(gameObject);
    }
}
