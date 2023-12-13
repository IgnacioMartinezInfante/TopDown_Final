using UnityEngine;
using UnityEngine.UI;

public class contadordiamantes : MonoBehaviour
{
    public Text diamantestexto; // Referencia al objeto de texto que mostrará la cantidad de monedas.
    public int contardiamantes = 0; // Inicializamos el contador de monedas a 0.
    public GameObject pantallavictoria;
    public GameObject jugadorfin;

    // Método para aumentar la cantidad de monedas.

    private void Start()
    {
        Updatediamantestexto();
        pantallavictoria.SetActive(false);
    }
    public void Increasecontardiamantes()
    {
        contardiamantes++;
        Updatediamantestexto(); 
    }

    private void Updatediamantestexto()
    {
        diamantestexto.text = "Diamantes: " + contardiamantes + "/10".ToString();
        if (contardiamantes >= 10)
        {
            pantallavictoria.SetActive(true);
            Time.timeScale = 0f;
            Destroy(jugadorfin);
        }
    }
}
