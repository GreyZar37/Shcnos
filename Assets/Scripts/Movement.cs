using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    private Animator animate;
    public GameObject light_;
    float horizontal;

    AudioSource audioSource;
    public AudioClip[] walkSound;
   

    public static bool hidden;
    public static bool crouching;

    public int keys = 0;

    SpriteRenderer SpriteRenderer_;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
        animate = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer_ = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        print(hidden);

        if (Input.GetKeyDown(KeyCode.R))
            {
            Application.Quit();
        }

        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, gameObject.transform.position.y);
        animate.SetFloat("Velocity", Mathf.Abs(horizontal));
        animate.SetBool("IsCrouching", crouching);

       

            if (Input.GetKey(KeyCode.C))
            {
                crouching = true;
                light_.SetActive(false);
            }
            else
            {
                crouching = false;
                light_.SetActive(true);
            }

            completeflip();

            if (!crouching)
            {
                walkAndRun();
            }
            else if (crouching)
            {
                crouch();
            }
            

        
        
       
    }

    void completeflip()
    {
        if (horizontal > 0)
       {
            transform.eulerAngles = new Vector3(0, 0, 0);
       } 

       else if (horizontal < 0)
       {
            transform.eulerAngles = new Vector3(0, 180, 0);
       }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (collision.gameObject.tag == ("Key"))
            {
                Debug.Log("ghdhfdhfd");
                Destroy(collision.gameObject);
                keys = keys + 1;
            }
        }
    }

  
    public void walkSounds()
    {
        audioSource.PlayOneShot(walkSound[Random.Range(0, walkSound.Length)]);
    }

    public void crouch()
    {
        speed = 2f;
    }
    public void walkAndRun()
    {
        light_.SetActive(true);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 6;
            animate.speed = 2;
        }
        else
        {
            speed = 4;
            animate.speed = 1;
        }
    }

}

