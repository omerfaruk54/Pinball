using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Renderer renderer2;
    public SpriteRenderer spriteRenderer;
    public Color defaultColor;
    public Color otherColor;   // Deðiþen renk inspector panelin olmasý gerektiði gibi gözüküyor ama siyaha deðiþiyor ayarlayamadým.
    public float colorDuration = 0.1f;
    private bool isChangingColor = false;
    private float elapsedTime = 0f;

    private void Awake()
    {
        renderer2 = GetComponent<Renderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
    }

    public void ChangeColor()
    {
        if (!isChangingColor)
        {
            spriteRenderer.color = otherColor;
            isChangingColor = true;
            elapsedTime = 0f;
        }
    }




    private void Update()
    {
        if (isChangingColor)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= colorDuration)
            {
                spriteRenderer.color = defaultColor;
                isChangingColor = false;
            }
        }
    }

}
