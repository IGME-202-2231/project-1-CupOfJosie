using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    //fields
    int score;

    [SerializeField]
    int lives;

    [SerializeField]
    GameObject player;

    [SerializeField]
    Text scoreObj;
    [SerializeField]
    Text livesObj;

    


    //properties
    public int Lives
    {
        get { return lives; }
        set { lives = value; }
    }
    public int Score
    {
        get { return score; }
        set { score = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreObj.text = "Score: " + score;
        livesObj.text = "Lives: " + lives;

        if(lives == 0)
        {
            Time.timeScale = 0;
        }

    }
}
