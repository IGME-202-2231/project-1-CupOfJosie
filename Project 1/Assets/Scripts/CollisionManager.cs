using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> enemies;

    [SerializeField]
    List<GameObject> bullets;

    public List<GameObject> Enemies
    {
        get { return enemies; }
        set { enemies = value; }
    }
    public List<GameObject> Bullets
    {
        get { return bullets; }
        set { bullets = value; }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      //if (AABB)
      //{
        foreach (GameObject enemy in enemies)
        {
            SpriteRenderer eBox = enemy.GetComponent<SpriteRenderer>();

            foreach (GameObject bullet in bullets)
            {
                SpriteRenderer bBox = bullet.GetComponent<SpriteRenderer>();

                if (AABBCollision(eBox.bounds, bBox.bounds))
                {
                    eBox.color = Color.red;
                    bBox.color = Color.red;
                }
            }
        }
    //}
      //else
      //{
      //    Info.text = "Circles";
      //    foreach (GameObject tree in trees)
      //    {
      //        SpriteRenderer tBox = tree.GetComponent<SpriteRenderer>();
      //        tBox.color = Color.white;
      //
      //        if (CircleCollision(vBox.bounds, tBox.bounds))
      //        {
      //            tBox.color = Color.red;
      //            vBox.color = Color.red;
      //        }
      //
      //    }
      //}
    }

    bool AABBCollision(Bounds vehicle, Bounds obstacle)
    {
        
        bool overX = (vehicle.min.x <= obstacle.max.x) && (vehicle.max.x >= obstacle.min.x);
        bool overY = (vehicle.min.y <= obstacle.max.y) && (vehicle.max.y >= obstacle.min.y);

        if (overX && overY)
        {
            return true;
        }
        
        return false;
    }

    bool CircleCollision(Bounds vehicle, Bounds obstacle)
    {
        //vehicle.center distance to obstacle.center
        //check if its larger than the radii
        float vRad;
        if(vehicle.extents.y > vehicle.extents.x)
        {
            vRad = vehicle.extents.x;
        }
        else
        {
            vRad = vehicle.extents.x;
        }

        float oRad = obstacle.extents.y;

        float distance = Mathf.Sqrt(Mathf.Pow((vehicle.center.x - obstacle.center.x), 2) + Mathf.Pow((vehicle.center.y - obstacle.center.y), 2));

        if(distance < (vRad + oRad))
        {
            return true;
        }
        return false;
    }



}
