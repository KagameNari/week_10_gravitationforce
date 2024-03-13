using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public Rigidbody rb; 
    const float G = 6.674f;

    static List<Attractor> attractors; 

    private void OnEnable()
    {
        if (attractors == null)
        {
            attractors = new List<Attractor>();
        }
        attractors.Add(this);
    }

    private void FixedUpdate()
    {
        foreach (Attractor attractor in attractors)
        {
            if (attractor != this)
            {
                Attract(attractor);
            }
        }
    }

    void Attract(Attractor other)
    {
        Rigidbody rb2 = other.rb;

        Vector3 direction = rb.position - rb2.position; 

        float distance = direction.magnitude;

        float forceMagnitude = G * (rb.mass * rb2.mass) / Mathf.Pow(distance, 2);

        Vector3 force = direction.normalized * forceMagnitude; 

        rb2.AddForce(force);
    }
}