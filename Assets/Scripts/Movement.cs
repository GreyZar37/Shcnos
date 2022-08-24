using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    private Animator animate;
    public GameObject light_;
    float horizontal;

    public static bool hidden;

    public int keys = 0;

    SpriteRenderer SpriteRenderer_;
    // Start is called before the first frame update
    void Start()
    {
        animate = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer_ = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       


        if (hidden)
        {
            rb.velocity = new Vector2(0, 0);
            light_.SetActive(false);
        }
       

        if (!hidden)
        {
            light_.SetActive(true);
            horizontal = Input.GetAxis("Horizontal");
            animate.SetFloat("Velocity", Mathf.Abs(horizontal));
            rb.velocity = new Vector2(horizontal * speed, gameObject.transform.position.y);
            completeflip();

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 6;
            }
            else
            {
                speed = 4;
            }

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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == ("Key"))
        {
            Destroy(collision.gameObject);
            keys = keys + 1;
        }
    }
}

