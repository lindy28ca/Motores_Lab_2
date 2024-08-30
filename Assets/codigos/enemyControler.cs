using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControler : MonoBehaviour
{
    SpriteRenderer ce;
    public Color color;
    public GameObject movimiento;
    public float velocidad;
    private void Awake()
    {
        ce = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        ce.color = color;
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movimiento.transform.position, velocidad * Time.deltaTime);
    }
    public void SigientePuntoDeControl(GameObject NuevoMovimiento)
    {
        movimiento = NuevoMovimiento;
    }
}
