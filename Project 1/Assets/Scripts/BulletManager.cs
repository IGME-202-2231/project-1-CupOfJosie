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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
    }

    public void Spawn()
    {
        cm.Bullets.Add(Instantiate(bulletPre, playerPos, new Quaternion(0,0,0,0)));
        //cm.Bullets.Add(bullet);
        //Instantiate(bulletPre);
    }
}
