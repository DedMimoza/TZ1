using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class movment : MonoBehaviour
{
    private GameObject _gameObject;
    private Pers _pers;

    void Start()
    {
        _pers = new Pers(gameObject);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        _pers.Movment();
        _pers.Rotate_head();
        if (Input.GetKeyDown(KeyCode.F))
        {
            _pers.Get_obj();
        }
    }
}
