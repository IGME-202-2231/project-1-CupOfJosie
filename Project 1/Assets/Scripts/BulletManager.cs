using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    CollisionManager cm;
    [SerializeField]
    GameObject bulletPre;

    Vector3 playerPos;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        timer -= Time.deltaTime;
    }

    public void Spawn()
    {
        if(timer <= 0)
        {
            cm.Bullets.Add(Instantiate(bulletPre, playerPos, new Quaternion(0,0,0,0)));
            timer = 0.1f;
        }

        //cm.Bullets.Add(bullet);
        //Instantiate(bulletPre);
    }
}
