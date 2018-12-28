using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arm_movement : MonoBehaviour
{
    protected Transform T;
    protected virtual void Awake() { T = transform; } //caches original transform, this might be useful later.
    // Start is called before the first frame update
    public float stretchSpeed = -0.001f;
    public float stretchMin = 0.002f;
    public float stretchMax = 1;
    void Start(){

    }

    // Update is called once per frame
    void Update(){
        movement();
    }
    void movement(){
            //arm can not have an x scale smaller than stretchmin, and cannot be greater than stretchmax
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector2 scale = transform.localScale;
            if (Input.GetKey("left") && transform.localScale.x < stretchMax){
                scale.x += stretchSpeed * Time.deltaTime;
                Debug.Log("left held down,");
                transform.localScale = scale;
           }
           if (Input.GetKey("right") && transform.localScale.x > stretchMin){
            scale.x += (-stretchSpeed) * Time.deltaTime;
            Debug.Log("right held down,");
            transform.localScale = scale;
        }
    }
}
