using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GravityManager : MonoBehaviour
{

private GameObject[] boxes;
private Rigidbody[] rbs;
public GameObject plane;
public GameObject reference;

private Vector3 direction;
public float gravityForce;

    void Start()
    {
        boxes = GameObject.FindGameObjectsWithTag("boxes");
        rbs = new Rigidbody[boxes.Length];

        for (int i = 0; i < boxes.Length; ++i)
        {
            GameObject door = boxes[i];
            rbs[i] = door.GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        ApplyGravity();
    }

    void ApplyGravity()
    {
        direction = plane.transform.position - reference.transform.position;
        foreach (Rigidbody rb in rbs)
            rb.AddForce(direction.normalized * gravityForce);
    }

    public void AllowGravity()
    {
        foreach (Rigidbody rb in rbs)
            rb.isKinematic = false;
    }
}
