using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject position;
    public GameObject projectile;
    public float force;

    private int maxPoints = 0;
    private int points = 0;
    private int ammo = 0;

    private bool playing = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (playing)
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

    public void SetUp(int ammo, int maxPoints)
    {
        points = 0;
        this.maxPoints = maxPoints;
        this.ammo = ammo;

        playing = true;
    }

    public void CleanUp()
    {
        points = 0;
        maxPoints = 0;
        ammo = 0;

        playing = false;
    }
}
