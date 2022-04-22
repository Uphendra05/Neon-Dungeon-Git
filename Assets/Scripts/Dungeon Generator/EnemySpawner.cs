using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int count;
    public float range = 10.0f;

    public float timeToSpawn;

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
    private void Update()
    {
        if (timeToSpawn <= 0)
        {


            StartCoroutine(EnemySpawning());

            timeToSpawn = 15f;




        }
        else
        {
            timeToSpawn -= Time.deltaTime;
           
        }


        IEnumerator EnemySpawning()
        {
            while(count<10)
            {
                Vector3 point;
                if (RandomPoint(transform.position, range, out point))
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);                    
                    Instantiate(enemy, point, Quaternion.identity);
                    yield return null;
                    count += 1;

                }

            }

            count = 0;
        }







      
       



    }

  


}
