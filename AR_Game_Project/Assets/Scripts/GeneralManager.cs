using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeneralManager : MonoBehaviour
{
    private GameObject[] boxes;
    private Rigidbody[] rbs;
    private GameObject plane;
    private GameObject reference;
    
    private Vector3 direction;
    public float gravityForce;

    private bool hasLevel = false;
    private Player player;

    void Start()
    {
        boxes = GameObject.FindGameObjectsWithTag("boxes");
        rbs = new Rigidbody[boxes.Length];

        for (int i = 0; i < boxes.Length; ++i)
        {
            GameObject door = boxes[i];
            rbs[i] = door.GetComponent<Rigidbody>();
        }

        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void ApplyGravity()
    {
        direction = plane.transform.position - reference.transform.position;
        foreach (Rigidbody rb in rbs)
            rb.AddForce(direction.normalized * gravityForce * rb.mass);
    }

    void Update()
    {
        if (hasLevel)
            ApplyGravity();
    }

    public void LevelSpawned(int maxAmmo)
    {
        plane = GameObject.Find("Ground");
        reference = GameObject.Find("GravityReference");

        foreach (Rigidbody rb in rbs)
            rb.isKinematic = false;

        player.SetUp(maxAmmo, 3);

        hasLevel = true;
    }
    public void LevelDespawned()
    {
        foreach (Rigidbody rb in rbs)
            rb.isKinematic = true;

        player.CleanUp();

        hasLevel = false;
    }
}
