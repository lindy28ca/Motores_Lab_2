using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puntosDeControl : MonoBehaviour
{
    public GameObject NuevoMovimiento;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<enemyControler>().SigientePuntoDeControl(NuevoMovimiento);
        }
    }
}
