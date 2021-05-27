using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Player player;

    private bool used = false;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (used)
            return;

        if (collision.transform.name == "Ground")
        {
            used = true;
            player.AddPoint();
        }
    }
}
