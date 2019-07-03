using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class bird_behavior : MonoBehaviour
{
    public bool birdInLeftHand, birdInRightHand;
    public Animator animator;
    public bool retreiving;
    private GameObject retreiveTo;
    public float speed = 1.0f;
    public float roostTime = 5.0f;
    public float flightspeed;
    private GameObject[] roosts;
    public GameObject newRoost;
    public GameObject curRoost;
    public bool isRoosting;
    // Start is called before the first frame update
    void Start()
    {
        //set arm flags to false
        animator.SetBool("isFlying", true);
        birdInLeftHand = false;
        birdInRightHand = false;
        //find the object armcenter
        retreiveTo = GameObject.Find("leftHand");
            roosts = GameObject.FindGameObjectsWithTag("roost");
        getRoost();
    }

    // Update is called once per frame
    void Update()
    {
          //every frame check if 
        birdRetrieve();
        birdFly();
       
    }
    void birdFly(){
        roostTime -= Time.deltaTime;
        if(!retreiving && roostTime <= 0 || !isRoosting){        
                transform.position = Vector2.MoveTowards(transform.position, newRoost.transform.position, flightspeed*Time.deltaTime);
                ///better than ontriggerenter because it lets the bird get to the center of the roost
                if(gameObject.transform.position == newRoost.transform.position){
                    getRoost();
                    roostTime = 5.0f;            
                    isRoosting = true;
                    animator.SetBool("isFlying", false);
                }
        }
        
    }
    void getRoost(){
        //get first roost
        int randRoost = UnityEngine.Random.Range(0,(roosts).Length);
        curRoost = newRoost;
        newRoost = roosts[randRoost];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered bird");
        if (other.tag == "leftHand")
        {
            Debug.Log("left hand enter bird");
            birdInLeftHand = true;
            other.GetComponent<arm_movement>().birdInHand = true;
        }
        if (other.tag == "rightHand")
        {
            Debug.Log("right hand enter bird");
            birdInRightHand = true;
            other.GetComponent<arm_movement>().birdInHand = true;
          }
        if(other.tag == "roost" && other.gameObject == newRoost){
            Debug.Log("bird entered roost");
            //reset timer and get new roost
            
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "leftHand")
        {
            Debug.Log("left hand exit bird");
            birdInLeftHand = false;
            other.GetComponent<arm_movement>().birdInHand = false;
        }
        if (other.tag == "rightHand")
        {
            Debug.Log("right hand exit bird");
            birdInRightHand = false;
            other.GetComponent<arm_movement>().birdInHand = false;
        }
        if(other.tag == "roost"){
            isRoosting = false;
            animator.SetBool("isFlying", true);
            Debug.Log("bird left roost");
        }
    }
    void birdRetrieve()
    {
          //detect if both hands are touching
          if (birdInLeftHand && birdInRightHand)
          {
               retreiving = true;
               Debug.Log("bird is traveling to player");
               float step = speed * Time.deltaTime*Math.Abs((float)Math.Log(speed));

               // move sprite towards the target location
               transform.position = Vector2.MoveTowards(transform.position, retreiveTo.transform.position, step);
               //transform.position = retreiveTo.transform.position;
               //if true make the birds parent the hand
          }
          else
          retreiving = false;
    }
}
