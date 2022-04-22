using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Player player;
    public int Health = 100;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        if (player == null)
        {
            Agent.isStopped = true;
            Time.timeScale = 0;
            return;
         
        }
        Agent.SetDestination(player.transform.position);
       



    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            HealthjManager.instance.DamagePlayer();
        }
    }

}
