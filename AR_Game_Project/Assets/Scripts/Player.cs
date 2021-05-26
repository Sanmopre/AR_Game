using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject position;
    public GameObject projectile;
    public float force;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject current = Instantiate(projectile);
            current.transform.SetPositionAndRotation(position.transform.position, position.transform.rotation);
            current.GetComponent<Rigidbody>().AddForce(position.transform.forward * force);
        }
    }
}
