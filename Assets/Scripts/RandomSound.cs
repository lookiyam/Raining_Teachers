using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    //make a public variable to get audiosurce sounds
    private AudioSource source;
    //make a public variable for add an array of sounds
    public AudioClip[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        //add a random array of sounds
        int randSound = Random.Range(0, sounds.Length);
        source.clip = sounds [randSound];
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
