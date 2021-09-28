using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    void Start()
    {
        Spawner();
    }

    void Spawner()
    {
        for (int i = 0; i < 15; i++)
        {

            if (i < 5)
            {
                spawnobj("Cube");
            }
            else if (i <10 )
            {
                spawnobj("Sphere");
            }
            else
            {
                spawnobj("Cylinder");
            }

        }
    }

    private void spawnobj(string name)
    {
        GameObject gm = null;
        switch (name)
        {
            case "Cube":
                gm = GameObject.CreatePrimitive(PrimitiveType.Cube);
                break;
            case "Cylinder":
                gm = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                break;
            case "Sphere":
                gm = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                break;
        }
        
        gm.transform.position = new Vector3(Random.Range(-45f, 45f), 0.5f, Random.Range(-45f, 45f));
        gm.GetComponent<Renderer>().material.color = Color.red;
        gm.transform.tag = "obj";
        gm.transform.name = name;
        Rigidbody rb = gm.AddComponent<Rigidbody>();
        gm.AddComponent<Obued>();
        
        //rb.isKinematic = true;
    }
}
