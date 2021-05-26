using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GravityManager : MonoBehaviour
{

private GameObject[] boxes;
private Rigidbody2D[] rbs;

    void Start()
    {
        boxes = GameObject.FindGameObjectsWithTag("boxes");
        rbs = new Rigidbody2D[boxes.Length];

        for (int i = 0; i < boxes.Length; ++i)
        {
            GameObject door = boxes[i];
            rbs[i] = door.GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        ApplyGravity();
    }

    void ApplyGravity()
    {
        foreach (Rigidbody2D rb in rbs)
        {
            //Add force perpendicular to the plane
            //rb.AddForce();
        }
    }

}
