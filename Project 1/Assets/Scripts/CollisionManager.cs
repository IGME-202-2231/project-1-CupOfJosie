using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> enemies;

    [SerializeField]
    List<GameObject> piglets;

    [SerializeField]
    List<GameObject> bullets;

    [SerializeField]
    GameObject pigPrefab;
    [SerializeField]
    GameObject player;

    //others
    List<GameObject> killables;
    public float timer;


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
        timer = 1;
        enemies = new List<GameObject>();
        bullets = new List<GameObject>();
        piglets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //initialize set variables
        killables = new List<GameObject>();
        SpriteRenderer pBox = player.GetComponent<SpriteRenderer>();
        if(timer > 0)
        {
            timer = timer - Time.deltaTime;
        }

        //bullet collisions with enemies
        foreach (GameObject bullet in bullets)
        {
            SpriteRenderer bBox = bullet.GetComponent<SpriteRenderer>();
            if (bullet.transform.position.y > 5)
            {
                killables.Add(bullet);
            }

            foreach (GameObject enemy in enemies)
            {
                SpriteRenderer eBox = enemy.GetComponent<SpriteRenderer>();

                if (AABBCollision(eBox.bounds, bBox.bounds))
                {
                    if(enemy.tag == "fox")
                    {
                        killables.Add(enemy);
                    }

                    killables.Add(bullet);
                }

            }

        }

        //player collision with enemies and pigs
        foreach(GameObject enemy in enemies)
        {
            SpriteRenderer eBox = enemy.GetComponent<SpriteRenderer>();

            if (enemy.transform.position.y < -5)
            {
                killables.Add(enemy);
            }

            if (AABBCollision(eBox.bounds, pBox.bounds))
            {
                if(timer <= 0)
                {
                    player.GetComponent<PlayerManager>().Lives--;
                }
                timer = 1;
            }

        }
        if(piglets.Count > 0)
        {
            foreach(GameObject pig in piglets)
            {
                SpriteRenderer pigBox = pig.GetComponent<SpriteRenderer>();

                if (pig.transform.position.y < -5)
                {
                    killables.Add(pig);
                }

                if(AABBCollision(pigBox.bounds, pBox.bounds))
                {
                    player.GetComponent<PlayerManager>().Score += 100;
                    killables.Add(pig);
                }
            }
        }


        foreach(GameObject victim in killables)
        {
            Kill(victim);
        }

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

    public void Kill(GameObject victim)
    {
        if (enemies.Contains(victim))
        {
            if(victim.tag == "fox")
            {
                //create piglet
                piglets.Add(Instantiate(pigPrefab, victim.transform.position, pigPrefab.transform.rotation));
            }
            enemies.Remove(victim);
            Destroy(victim);
        }
        if (bullets.Contains(victim))
        {
            bullets.Remove(victim);
            Destroy(victim);
        }
        if (piglets.Contains(victim))
        {
            piglets.Remove(victim);
            Destroy(victim);
        }
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
