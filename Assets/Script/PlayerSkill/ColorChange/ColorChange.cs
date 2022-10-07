using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour,IColor
{
    private Color currntColor;
    private SpriteRenderer spriteRenderer;
    private CristalsColorChanger colorChanger;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CristalsColorChanger>())
        {
            colorChanger = collision.gameObject.GetComponent<CristalsColorChanger>();
            this.currntColor = colorChanger.colorToChangeInto;
            spriteRenderer.color = currentColor();
            Destroy(collision.gameObject);
        }
    }

    public Color currentColor()
    {
        return this.currntColor;
    }
}
