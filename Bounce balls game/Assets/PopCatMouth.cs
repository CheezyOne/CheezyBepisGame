using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopCatMouth : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite est;
    public Sprite shut;


    void OnTriggerStay2D()
    {
        if (spriteRenderer)
        spriteRenderer.sprite = shut;
    }
    void OnTriggerExit2D()
    {
        if (spriteRenderer)
        spriteRenderer.sprite = est;
    }
}
