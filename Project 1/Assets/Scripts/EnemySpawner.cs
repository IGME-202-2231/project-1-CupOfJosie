using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    CollisionManager cm;

    [SerializeField]
    GameObject foxPre;

    [SerializeField]
    GameObject cactusPre;

    float timer;

    void Start()
    {
        timer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            float rnd = Random.value;
            if(rnd > 0.5)
            {
                cm.Enemies.Add(Instantiate(foxPre, new Vector3(Random.Range(-7f, 7f), 6f), foxPre.transform.rotation));
            }
            else
            {
                cm.Enemies.Add(Instantiate(cactusPre, new Vector3(Random.Range(-7f, 7f), 6f), cactusPre.transform.rotation));
            }
            timer = 2;
        }
    }
}
