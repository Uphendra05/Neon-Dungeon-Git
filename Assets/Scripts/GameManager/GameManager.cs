using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int enemiesKilled;
    public int relicsRemaining;
    public GameObject gameWin;
    public Text enemiesText;
    public Text relicsText;

    public static GameManager instance;
    private void Awake()
    {
        if(instance == null)
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

        enemiesText.text = enemiesKilled.ToString();
        relicsText.text = relicsRemaining.ToString();
        if(relicsRemaining <= 0)
        {
            Time.timeScale = 0;
            gameWin.SetActive(true);
        }
        
    }
}
