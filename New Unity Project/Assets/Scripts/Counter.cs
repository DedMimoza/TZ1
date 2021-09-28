using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class Counter : MonoBehaviour
{
    private TextMeshProUGUI _textcube;
    private TextMeshProUGUI _textsphere;
    private TextMeshProUGUI _textcylinder;

    private GameObject panel;

    private static int countercub;
    private static int counterspher;
    private static int countercyl;
    void Start()
    {
        countercub = 0;
        countercyl = 0;
        counterspher = 0;
        panel = GameObject.Find("Panel");
        panel.SetActive(false);
       _textcube = GameObject.Find("textcube").GetComponent<TextMeshProUGUI>();
       _textsphere = GameObject.Find("textspher").GetComponent<TextMeshProUGUI>();
       _textcylinder = GameObject.Find("textcylinder").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _textcube.text = $"Cubes collected: {countercub}";
        _textcylinder.text = $"Cylinders collected: {countercyl}";
        _textsphere.text = $"Spheres collected: {counterspher}";
        if (countercub == 5 && countercyl == 5 && counterspher == 5 && !Cursor.visible)
        {
            panel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public static void adder(string name)
    {
        switch (name)
        {
            case"Cube":
                countercub++;
                break;
            case"Cylinder":
                countercyl++;
                break;
            case"Sphere":
                counterspher++;
                break;
        }
    }

    public void reload()
    {
        SceneManager.LoadScene(0);
    }
}
