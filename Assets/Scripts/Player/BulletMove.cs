using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * speed*Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {

            Destroy(other.gameObject);
            GameManager.instance.enemiesKilled++;
        }

        if (other.gameObject.CompareTag("Wall"))
        {

            Destroy(gameObject);
        }

    }
}
