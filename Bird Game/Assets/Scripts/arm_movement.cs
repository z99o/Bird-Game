using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arm_movement : MonoBehaviour
{
    protected Transform T;
    protected virtual void Awake() { T = transform; } //caches original transform, this might be useful later.
    // Start is called before the first frame update
    public float stretchSpeed = 0.1f;
    public float stretchDistance = 15;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement();        
    }
    void movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Horizontal") && transform.localScale.x < stretchDistance)
        {
            float movement = stretchSpeed * moveHorizontal;
            Vector2 scale = transform.localScale;
            scale.x += movement;
            transform.localScale = scale;
            transform.position = (Vector2)transform.position + Vector2.left * (scale);
        }   

    }
}
