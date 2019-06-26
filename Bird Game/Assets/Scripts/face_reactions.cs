using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class face_reactions : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite defaultFace;
    public Sprite hurtFace;
    public Sprite hurtFace_bad;
    public Sprite happyFace;
    public int status; //0 = default | 1 = Happy | 2 = Hurt | 3 = Hurt bad |
    void Start()
    {
        
        status = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if I have a status number from the main I can do a switch case instead
        switch(status){
        case(0):
            GetComponent <SpriteRenderer>().sprite = defaultFace;
            break;
        case(1):
            break;
        case(2):
            break;
        case(3):
            break;
        }
    }
}
