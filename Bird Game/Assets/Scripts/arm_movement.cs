using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class arm_movement : MonoBehaviour
{
    protected Transform T;
    protected virtual void Awake() { T = transform; } //caches original transform, this might be useful later.
    // Start is called before the first frame update
    public float stretchSlowdown = 1;
    public float stretchSnapback = 1;
    public float stretchSpeed = -0.001f;
    public float stretchMin = 0.2f;
    public float stretchMax = 1;
    public float rotateMax = 95;
    public float rotateMin = -95;
    public float rotateSpeed = 10;
    private string extend, retract, up, down;
    void Start() {
        if(this.tag == "rightArm"){
            extend = "a";
            retract = "d";
            up = "w";
            down = "s";
        }
        else{
            extend = "left";
            retract = "right";
            up = "up";
            down = "down";
        }
        transform.Rotate(0, 0, 360);
    }
    // Update is called once per frame
    void Update(){
        armStretch();
        armRotate();
    }
    void armStretch(){
            //arm can not have an x scale smaller than stretchmin, and cannot be greater than stretchmax
            //float moveHorizontal = Input.GetAxis("Horizontal");
            //float moveVertical = Input.GetAxis("Vertical");
            Vector2 scale = transform.localScale;
           if (Input.GetKey(extend) && transform.localScale.x < stretchMax){
                scale.x += (stretchSpeed * Time.deltaTime)*Math.Abs((float)Math.Log(stretchSlowdown*transform.localScale.x));
                //Debug.Log("left held down,");
                transform.localScale = scale;
           }
           if (Input.GetKey(retract) && transform.localScale.x > stretchMin){
                scale.x += (-stretchSpeed * Time.deltaTime)*Math.Abs(((float)Math.Log(transform.localScale.x*stretchSnapback)));
                //Debug.Log("right held down,");
                transform.localScale = scale;
        }
    }
    void armRotate() {
        //Debug.Log("transform.localRotation.z " + transform.localRotation.z);
        if (Input.GetKey(up) && transform.localRotation.z <= rotateMin) {
            transform.Rotate(0, 0, -Time.deltaTime * rotateSpeed);
            //Debug.Log("up held down");
        }
        if (Input.GetKey(down) && transform.localRotation.z >= rotateMax)
        {
            transform.Rotate(0,0,Time.deltaTime*rotateSpeed);
            //Debug.Log("down held down,");
        }
    }
}
