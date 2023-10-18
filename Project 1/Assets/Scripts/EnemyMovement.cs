using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyMovement : MonoBehaviour
{
    //fields

    Vector3 objectPosition = Vector3.zero;
    Vector3 direction = Vector3.down;
    Vector3 velocity = Vector3.zero;

    [SerializeField]
    float speed = 1.0f;

    float sWidth;
    float sHeight;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    Rect carRect;
    Rect screen;


    // Start is called before the first frame update
    void Start()
    {
        objectPosition = transform.position;
        sWidth = Screen.width;
        sHeight = Screen.height;
        screen = new Rect(0, 0, sWidth, sHeight);
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed * Time.deltaTime;

        if (transform.position.y < -5)
        {
            transform.position = new Vector3(transform.position.x, -5);
        }
        if (transform.position.x > 8)
        {
            transform.position = new Vector3(8, transform.position.y);
        }
        if (transform.position.x < -8)
        {
            transform.position = new Vector3(-8, transform.position.y);
        }

        objectPosition = transform.position;

        objectPosition += velocity;


        // check for OOB / validate position
        transform.position = objectPosition;

    }
}
