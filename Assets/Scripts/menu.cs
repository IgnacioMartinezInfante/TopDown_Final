using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void CargarJuego()
    {
        SceneManager.LoadScene("juego");
        Time.timeScale = 1f;
    }

    public void Cargarcreador()
    {
        SceneManager.LoadScene("creador");
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
