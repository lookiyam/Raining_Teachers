using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //speed floats
    public float minSpeed;
    public float maxSpeed;

    //store speed of enemy
    float speed;

    //Access to player script
    Player playerScript;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        //set speed between min and max
        speed = Random.Range(minSpeed, maxSpeed);
        //access player scritpt with tag player
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //down movement
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    //detect collision
    //calculate damage
    void OnTriggerEnter2D(Collider2D hitObject) 
    {
        if(hitObject.tag == "Player")
        {
            playerScript.TakeDamage(damage);
        }
    }
}
