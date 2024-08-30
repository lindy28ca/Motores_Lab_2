using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changecolorControl : MonoBehaviour
{
    public GameObject prota;
    public Color color;
    public void changeColor()
    {
        prota.GetComponent<SpriteRenderer>().color = color;
        prota.tag = gameObject.tag;
    }
}
