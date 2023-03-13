using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSquare : MonoBehaviour
{
    [SerializeField] GameObject movingSquare;
    [SerializeField] Vector3 startPos;
    [SerializeField] float speed;


    public Renderer renderer2;
    public SpriteRenderer spriteRenderer;
    public Color defaultColor;
    public Color otherColor;
    public float colorDuration = 0.1f;
    private bool isChangingColor = false;
    private float elapsedTime = 0f;

    private void Awake()
    {
        movingSquare.gameObject.SetActive(false);
        renderer2 = GetComponent<Renderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
    }
    IEnumerator Start()
    {
        startPos = transform.position;


        while (true)
        {
            movingSquare.transform.position = new Vector3(startPos.x, Mathf.PingPong(Time.time * speed, 5) + startPos.y, 0);

            yield return null;
        }
    }

    public void MovingSquareChangeColor()
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
