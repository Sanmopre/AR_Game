using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject position;
    public GameObject projectile;
    public float force;

    public int maxPoints;
    private int points;
    private int ammo;

    void Start()
    {
        
    }

    void Update()
    {
        if (ammo <= 0)
        {
            // Lose Screen
            Debug.Log("LOSE");
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        --ammo;

        GameObject current = Instantiate(projectile);
        current.transform.SetPositionAndRotation(position.transform.position, position.transform.rotation);
        current.GetComponent<Rigidbody>().AddForce(position.transform.forward * force);
    }

    public void AddPoint()
    { 
        ++points;
        Debug.Log("ADDED POINT");
        if (points == maxPoints)
        {
            // Win Screen
            Debug.Log("WIN");
        }
    }
}
