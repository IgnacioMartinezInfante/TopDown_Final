using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientojugador : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public GameObject bala;
    public contadorbalas contadorBalas;
    public Transform puntaArma;

    void Update()
    {
        moverjugador();
        CheckInput();
    }
    void moverjugador()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        movement.Normalize();

        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 lookDirection = mousePosition - transform.position;
        lookDirection.z = 0f; 
        lookDirection.Normalize();

        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DispararBala();
        }
    }
    void DispararBala()
    {
        if (contadorBalas != null && contadorBalas.contarbalas > 0)
        {
            Vector2 puntoDeDisparo = puntaArma.position;

            RaycastHit2D hit = Physics2D.Raycast(puntoDeDisparo, puntaArma.right);

            GameObject balaInstancia = Instantiate(bala, puntoDeDisparo, Quaternion.identity);

            float angle = Mathf.Atan2(puntaArma.right.y, puntaArma.right.x) * Mathf.Rad2Deg;

            balaInstancia.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            
            Rigidbody2D rb = balaInstancia.GetComponent<Rigidbody2D>();

            rb.AddForce(puntaArma.right * 5, ForceMode2D.Impulse);

            Destroy(balaInstancia, 5);

            contadorBalas.Decreasecontarbalas();
        }
    }
}
