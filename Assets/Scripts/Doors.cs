using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Doors : MonoBehaviour
{

    public AudioClip[] DoorSounds;
    public AudioClip DoorSoundLocked;
    AudioSource audioSource;
    public Light2D light2D;


    public GameObject block;
    float doorOpenTimer = 1;
    float currentTimer;

    public bool locked;

    bool opening;

    // Start is called before the first frame update
    void Start()
    {
        light2D = gameObject.GetComponentInChildren<Light2D>();
        currentTimer = doorOpenTimer;
        audioSource = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
      
    }

    // Update is called once per frame
    void Update()
    {
       

        if (opening)
        {
            currentTimer -= Time.deltaTime;

            if(light2D.intensity <= 1.5f)
            {
                light2D.intensity += Time.deltaTime * 1.5f;
            }
           

           
        }
        else if (light2D.intensity > 0f)
        {
            light2D.intensity -= Time.deltaTime * 1.5f;
            if (light2D.intensity < 0)
            {
                light2D.intensity = 0;
            }

        }

        else
        {
            light2D.intensity = 0;
        }

        if(currentTimer <= 0)
        {
            block.SetActive(false);
        }
        else
        {
            block.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           

            if (locked)
            {
                audioSource.PlayOneShot(DoorSoundLocked, 0.2f);

            }
            else
            {
                opening = true;
                audioSource.PlayOneShot(DoorSounds[0], 0.5f);
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (locked)
            {

            }
            else
            {
                audioSource.PlayOneShot(DoorSounds[1], 0.5f);
                currentTimer = doorOpenTimer;
                opening = false;
            }
         

        }

    }

   
}
