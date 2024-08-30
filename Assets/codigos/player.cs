using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    Rigidbody2D prota;
    float horizontal;
    bool saltar;
    bool unSalto;
    bool dosSaltos;
    RaycastHit2D rayo;
    public const int maxVida = 10;
    public Scrollbar scrollbar;
    public float vidas;
    public float velocidad;
    public float fuerzaSalto;
    public LayerMask layer;
    public GameObject perdiste;
    public GameObject ganaste;
    public Button button;
    public Button boton;
    SpriteRenderer Renderer;

    private void Awake()
    {
        prota = GetComponent<Rigidbody2D>();
        Renderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        scrollbar.size = vidas / maxVida;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            saltar = true;
        }
        if(vidas <= 0)
        {
            perdiste.SetActive(true);
            TiempoDelJuego(0);
        }
    }
    private void Start()
    {
        TiempoDelJuego(1);
    }
    private void FixedUpdate()
    {
        prota.velocity = new Vector2(horizontal * velocidad, prota.velocity.y);
        CheckRaycast();
        if (saltar == true)
        {
            if (unSalto == true)
            {
                prota.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
                saltar = false;
            }
            else if (dosSaltos == true)
            {
                prota.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
                dosSaltos = false;
            }
        }
    }
    private void CheckRaycast()
    {
        rayo = Physics2D.Raycast(transform.position, Vector2.down, 1.03f, layer);
        if (rayo.collider != null)
        {
            unSalto = true;
            dosSaltos = true;
        }
        else
        {
            unSalto = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            button.interactable = false;
            boton.interactable = false;

           if(Renderer.color != collision.gameObject.GetComponent<SpriteRenderer>().color)
            {
                vidas = vidas -1;
            }
        }
        if(collision.gameObject.tag == "finish")
        {
            ganaste.SetActive(true);
            TiempoDelJuego(0);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            button.interactable = true;
            boton.interactable = true;
        }
    }
    public void TiempoDelJuego(int a)
    {
        Time.timeScale = a;
    }
}
