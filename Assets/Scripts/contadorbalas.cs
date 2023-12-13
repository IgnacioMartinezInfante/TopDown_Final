using UnityEngine;
using UnityEngine.UI;

public class contadorbalas : MonoBehaviour
{
    public Text balastexto; 
    public int contarbalas = 0; 

    private void Start()
    {
        Updatebalastexto();
    }
    public void Increasecontarbalas()
    {
        contarbalas = contarbalas + 3;
        Updatebalastexto(); 
    }

    public void Decreasecontarbalas()
    {
        contarbalas--;
        Updatebalastexto(); 
    }

    private void Updatebalastexto()
    {
        balastexto.text = "Balas: " + contarbalas.ToString();
    }
}
