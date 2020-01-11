using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//use UI library
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //public variable for Lose Screen
    public GameObject losePanel;
    //Display Health withing Text
    public Text healthDisplay;
    //create a variable dor rigid body 2d in order to move the player
    Rigidbody2D rb;
    //create reference to Animator
    Animator anim;

    //Audio variable
    AudioSource source;

    //variable for health
    public int health;
    
    //Add a speed variable, public so that can be modified
    public float speed;

    
    //make a private variable in order to use the animation not only on the fixupdate fuction
    private float input;
    // Start is called before the first frame update
    void Start()
    {
        //get audio source variable
        source = GetComponent<AudioSource>();
        //get the rigidbody 2d
        rb = GetComponent<Rigidbody2D>();
        //get aimator component
        anim = GetComponent<Animator>();
        //Ui text read Health value
        healthDisplay.text = health.ToString();

    }

    private void Update() 
    {
        //if input is not equal to 0
        //isRunning animation is true
        //else input is equal to 0 isRunning is false
        if (input!= 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        //if input grater than 0 (moving right)
        // DO NOT rotate the player
        //else input less than 0 (moving left)
        //ROTATE the player
        if (input > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        
        else if (input < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    // Update is called once per frame
    //since I'm using the physics engine, change from Update function to Fxixed Update function
    void FixedUpdate()
    {

        //STORE PLAYER INPUTS

        //create a float because the movement value will be from -1 to +1
        //use Raw to get rid to the smoothing of the value between -1 and +1
        input = Input.GetAxisRaw("Horizontal");
        //print(input);

        //MOVING PLAYER
        //use a vector 2
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
    }

    // public function in order to calculate the damage within enemy script
    public void TakeDamage(int damageAmount)
    {
        //play audio source when hitted
        source.Play();
        health -= damageAmount;
        //display text whenever player takes damage
        healthDisplay.text = health.ToString();
        //if health <= zero
        //destroy player
        //active lose screen
        if(health <=0)
        {
            losePanel.SetActive(true);
            //destroy the player
            Destroy(gameObject);
        }
    }
}
