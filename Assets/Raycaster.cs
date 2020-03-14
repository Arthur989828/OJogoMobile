﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycaster : MonoBehaviour
{
    public TextMesh textDebug;
    public GameObject crosshair;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects 
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            textDebug.text = hit.transform.name;
            crosshair.transform.position = hit.point;

            if (hit.transform.gameObject.CompareTag("Player"))
            {
                crosshair.GetComponent<Image>().CrossFadeColor(Color.green, .5f, false, false);
            }
            else
            {
                crosshair.GetComponent<Image>().CrossFadeColor(Color.red, .5f, false, false);
            }
        }
    }
}