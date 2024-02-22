using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleFlappy : MonoBehaviour
{
    public float VitesseX;
    public float VitesseY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Vitesses horizontales 
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            VitesseX = 1;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            VitesseX = -1;
        }
        else // si on n'appuit pas sur aucune des touches de deplacement alors flappy perd de sa vitesse graduelement 
        {
            VitesseX = GetComponent<Rigidbody2D>().velocity.x;
        }

        // Vitesse verticale
        if (Input.GetKeyDown(KeyCode.W)  || Input.GetKeyDown(KeyCode.UpArrow))
        {
            VitesseY = 5;
        }
        else
        {
            VitesseY = GetComponent<Rigidbody2D>().velocity.y;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(VitesseX, VitesseY);

    }
}
