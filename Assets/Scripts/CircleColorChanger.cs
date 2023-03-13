using UnityEngine;

public class CircleColorChanger : MonoBehaviour
{
    public Renderer renderer2;
    public SpriteRenderer spriteRenderer;
    public Color defaultColor;
    public Color otherColor;
    public float colorDuration = 0.1f;
    private bool isChangingColor = false;
    private float elapsedTime = 0f;

    private void Awake()
    {
        renderer2 = GetComponent<Renderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
    }

    public void CircleChangeColor()
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
