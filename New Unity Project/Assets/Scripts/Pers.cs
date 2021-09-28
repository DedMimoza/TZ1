using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pers
{
    private GameObject telo;
    private GameObject head;
    private Rigidbody _teloRigidbody;
    
    public Camera playerCamera;
    private float lookSpeed = 2.0f;
    private float lookXLimit = 60.0f;
    float rotationX = 0;

    public Pers(GameObject person)
    {
        telo = person;
        _teloRigidbody = telo.GetComponent<Rigidbody>();
        playerCamera = person.transform.GetChild(0).GetComponent<Camera>();

    }


    public void Movment()
    {
        if (_teloRigidbody.velocity.magnitude < 5f)
        {
            _teloRigidbody.AddForce(
                telo.transform.TransformDirection(Vector3.forward) * (250f * Input.GetAxis("Vertical") * Time.deltaTime),
                ForceMode.Impulse);
            _teloRigidbody.AddForce(
                telo.transform.TransformDirection(Vector3.right) * (250f * Input.GetAxis("Horizontal") * Time.deltaTime),
                ForceMode.Impulse);
        }
    }

    public void Rotate_head()
    {
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        telo.transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }


    public void Get_obj()
    {
        RaycastHit hit;
        if (playerCamera.transform.childCount != 0)
        {
            playerCamera.transform.GetChild(0).transform.tag = "obj";
            playerCamera.transform.GetChild(0).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            playerCamera.transform.GetChild(0).transform.parent = null;
        }
        
        else if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0)), out hit, 2f))
        {
            Debug.Log(hit.collider.tag);
            if (hit.collider.CompareTag("obj"))
            {
                hit.collider.transform.SetParent(playerCamera.transform);
                hit.collider.gameObject.tag = "inh";
                hit.collider.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            }
        }
    }
    
}
