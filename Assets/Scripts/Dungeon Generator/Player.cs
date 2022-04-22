using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody playerRb;
    public GameObject bulletPrefab;
    public GameObject firePoint;

    public float fireRate;
    float nextFireAttack;

   
    
    void Start()
    {
        
    }

   
    void Update()
    {
        float horziontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horziontal, 0, vertical);
         movement.Normalize();
        playerRb.velocity = new Vector3(movement.x * moveSpeed , 0, movement.z * moveSpeed );
        //transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        // playerRb.AddForce();
        //playerRb.MovePosition(new Vector3(movement.x * moveSpeed, 0, movement.z * moveSpeed));

        RotatePlayer();

        if(Time.time >= nextFireAttack)
        {
            if (Input.GetMouseButton(0))
            {
                PlayerShoot();
                nextFireAttack = Time.time + 1f / fireRate;
            }

        }

       
    }

  

    public void RotatePlayer()
    {


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundplane = new Plane(Vector3.up, Vector3.zero);
        float rayplane;

        if (groundplane.Raycast(ray, out rayplane))
        {
            Vector3 pointtolook = ray.GetPoint(rayplane);
            Vector3 direction = pointtolook - transform.position;
            float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }
    }

    public void PlayerShoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);

        Destroy(bullet, 3f);


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            GameManager.instance.relicsRemaining--;
            Destroy(other.gameObject);
        }
    }

}
