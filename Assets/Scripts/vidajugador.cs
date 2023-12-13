using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidajugador : MonoBehaviour
{
    public int vidaInicial = 100; 
    private int vidaActual; 
    public GameObject pantalladerrota; 
    public Text vidatexto;

    private void Start()
    {
        vidaActual = vidaInicial; 
        pantalladerrota.SetActive(false); 
        vidatextofuncion();
    }

    public void reducirvidachoqueconzombie()
    {
        ReducirVida(10);
    }
    public void reducirvidabalatirador()
    {
        ReducirVida(20);
    }
    public void ReducirVida(int cantidad)
    {
        vidaActual -= cantidad; 
        vidatextofuncion();
        if (vidaActual <= 0)
        {
            pantalladerrota.SetActive(true);
            Time.timeScale = 0f;
            Destroy(gameObject);
        }
    }

    private void vidatextofuncion()
    {
        vidatexto.text = "Vida: " + vidaActual.ToString();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        vidaActual = vidaInicial; 
        pantalladerrota.SetActive(false); 
    }
}
