using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiradorcontrol : MonoBehaviour
{
    public float distancia = 2f;
    public float velocidad = 1f;
    public float tiempoespera;
    public GameObject balaPrefab;
    public Transform puntaarmatirador;

    public bool moverVertical = true;

    void Start()
    {
        StartCoroutine(MovimientoTirador());
        StartCoroutine(DispararBalaPeriodico());
    }

    IEnumerator MovimientoTirador()
    {
        while (true)
        {
            Vector3 objetivoInicial = transform.position;
            Vector3 objetivoFinal;

            if (moverVertical)
            {
                objetivoFinal = objetivoInicial + Vector3.up * distancia;
            }
            else
            {
                objetivoFinal = objetivoInicial + Vector3.right * distancia;
            }

            while (transform.position != objetivoFinal)
            {
                transform.position = Vector3.MoveTowards(transform.position, objetivoFinal, velocidad * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(tiempoespera);

            while (transform.position != objetivoInicial)
            {
                transform.position = Vector3.MoveTowards(transform.position, objetivoInicial, velocidad * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(tiempoespera);
        }
    }

    IEnumerator DispararBalaPeriodico()
    {
        while (true)
        {
            DispararBala();
            yield return new WaitForSeconds(tiempoespera);
        }
    }

    void DispararBala()
    {
        Vector2 puntoDeDisparo = puntaarmatirador.position;
        
        GameObject balaInstancia = Instantiate(balaPrefab, puntoDeDisparo, Quaternion.identity);

        float angle = Mathf.Atan2(puntaarmatirador.right.y, puntaarmatirador.right.x) * Mathf.Rad2Deg;

        balaInstancia.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        Rigidbody2D rb = balaInstancia.GetComponent<Rigidbody2D>();

        rb.AddForce(puntaarmatirador.right * 5, ForceMode2D.Impulse);

        Destroy(balaInstancia, 5);
    }
}
