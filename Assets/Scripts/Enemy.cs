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

    //Explotion particle game object
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        //set speed between min and max
        speed = Random.Range(minSpeed, maxSpeed);
        //access player scritpt 
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
        //if collide with player
        //destroy
        //emit particles explosion, on position and no rotation
        if(hitObject.tag == "Player")
        {
            playerScript.TakeDamage(damage);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        //If enemy collide with gorund
        //destroy enemy
        // emit particle explosion
        if(hitObject.tag == "Ground")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
