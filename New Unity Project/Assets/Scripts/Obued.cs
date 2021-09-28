using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obued : MonoBehaviour
{
    private void OnCollisionStay(Collision other)
    {
        if (other.collider.CompareTag(transform.name) && transform.parent == null)
        {
            Counter.adder(transform.name);
            Destroy(gameObject);
            
        }
    }
    
}
