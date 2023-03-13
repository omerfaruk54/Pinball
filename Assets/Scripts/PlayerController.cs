using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D leftArm;
    [SerializeField] private Rigidbody2D rightArm;

    public float power = 4000f;






    private bool IspressKeyLeft => Input.GetKeyDown(KeyCode.A);    
    private bool IspressKeyRight => Input.GetKeyDown(KeyCode.D);


    void Update()
    {
        if (IspressKeyLeft)
        {
            Hit(leftArm);
        }

        if (IspressKeyRight)
        {
            Hit(rightArm);
        }
    }

    public void Hit(Rigidbody2D current)
    {
        current.AddForce(Vector2.up * power);
        

    }

    public void LeftArm()
    {
        Hit(leftArm);
    }

    public void RightArm()
    {
        Hit(rightArm);
    }

}

