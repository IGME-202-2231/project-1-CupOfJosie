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

    [SerializeField]
    Vector3 direction = Vector3.down;

    Vector3 velocity = Vector3.zero;

    [SerializeField]
    float speed = 1.0f;

    float sWidth;
    float sHeight;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    public Vector3 Direction
    {
        get { return direction; }
        set { direction = value; }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        objectPosition = transform.position;
        sWidth = Screen.width;
        sHeight = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed * Time.deltaTime;

      //if (transform.position.y < 5)
      //{
      //    if (direction == Vector3.up)
      //    {
      //        cm.Kill(spriteRenderer.gameObject);
      //    }
      //}
      //if (transform.position.y < -5)
      //{
      //    if(direction == Vector3.down)
      //    {
      //        cm.Kill(spriteRenderer.gameObject);
      //    }
      //}

        objectPosition = transform.position;

        objectPosition += velocity;


        // check for OOB / validate position
        transform.position = objectPosition;

    }
}
