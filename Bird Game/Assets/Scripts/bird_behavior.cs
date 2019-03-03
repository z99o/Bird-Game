﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class bird_behavior : MonoBehaviour
{
    private bool birdInLeftHand, birdInRightHand;
    public bool retreiving;
    private GameObject retreiveTo;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        //set arm flags to false
        birdInLeftHand = false;
        birdInRightHand = false;
        //find the object armcenter
        retreiveTo = GameObject.Find("armCenter");
    }

    // Update is called once per frame
    void Update()
    {
          //every frame check if 
               birdRetrieve();
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered bird");
        if (other.tag == "leftHand")
        {
            Debug.Log("left hand enter bird");
            birdInLeftHand = true;
               // other.GetComponent<arm_movement>().birdInHand = true;
        }
        if (other.tag == "rightHand")
        {
            Debug.Log("right hand enter bird");
            birdInRightHand = true;
              // other.GetComponent<arm_movement>().birdInHand = true;
          }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "leftHand")
        {
            Debug.Log("left hand exit bird");
            birdInLeftHand = false;
        }
        if (other.tag == "rightHand")
        {
            Debug.Log("right hand exit bird");
            birdInRightHand = false;
        }
    }
    void birdRetrieve()
    {
          //detect if both hands are touching
          if (birdInLeftHand == true && birdInRightHand == true)
          {
               retreiving = true;
               Debug.Log("bird is traveling to player");
               float step = speed * Time.deltaTime*Math.Abs((float)Math.Log(speed+2));

               // move sprite towards the target location
               transform.position = Vector2.MoveTowards(transform.position, retreiveTo.transform.position, step);
               //if true make the birds parent the hand
          }
          else
          retreiving = false;
    }
}
