using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthjManager : MonoBehaviour
{
    public GameObject player;
    public int life;
    public GameObject gameOverScreen;
    public GameObject[] healthBar;

    public static HealthjManager instance;

    private void Awake()
    {
        gameOverScreen.SetActive(false);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        
    }

   
    void Update()
    {

        if (life <= 0)
        {
            player.SetActive(false);
            gameOverScreen.SetActive(true);

        }

    }

    public void DamagePlayer()
    {
        life -= 1;
        for (int i = 0; i < healthBar.Length; i++)
        {
            if (life > i)
            {
                healthBar[i].SetActive(true);
            }
            else
            {
                healthBar[i].SetActive(false);

            }


        }


    }
}
