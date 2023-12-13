using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;


public class controlenemigo : MonoBehaviour
{
    public int hpinicial = 50;
    public int velocidadRotacion = 5;
    private int hpactual;
    public GameObject energiaprefab;
    public GameObject diamanteprefab;
    public bool recompensa;

    void Start()
    {
        hpactual = hpinicial;
    }

    public void recibirDaño()
    {
        hpactual -= 25;
        if (hpactual <= 0)
        {
            this.desaparecer();
        }
    }

    private void desaparecer()
    {
        if (recompensa == true)
        {
            Instantiate(energiaprefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(diamanteprefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bala"))
        {
            recibirDaño();
        }

        if (collision.gameObject.CompareTag("jugador"))
        {
            vidajugador sacarvidaporchoque = GameObject.Find("jugador").GetComponent<vidajugador>();
            sacarvidaporchoque.reducirvidachoqueconzombie();
        }
    }
}