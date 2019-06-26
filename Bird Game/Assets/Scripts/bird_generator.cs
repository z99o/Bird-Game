using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird_generator : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
    public GameObject bird;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0){
            Instantiate(bird);
            timer = 10;
        }

    }
}
