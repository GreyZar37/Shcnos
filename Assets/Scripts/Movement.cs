using Cinemachine;
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
    bool pickingUp;
    public static bool crouching;

    public int keys = 0;
    bool closeToKey;
    bool closeToLockedDoor;

    GameObject currentItem;
    public Transform position1;
    public Transform position2;

    public GameObject key;
    
    [SerializeField]
    CinemachineVirtualCamera m_Camera;
    [SerializeField]
    float transition_Speed;

    [SerializeField]
    GameObject inventoryUI;

    [SerializeField]
    Animator animator;
    bool loadInventory;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
        animate = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        interact();
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.Quit();
        }

        horizontal = Input.GetAxis("Horizontal");
        if (pickingUp == false)
        {
            rb.velocity = new Vector2(horizontal * speed, gameObject.transform.position.y);

        }
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

        if (Input.GetKeyDown(KeyCode.Tab) && inventoryUI.activeInHierarchy == true)
        {
            inventoryUI.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && inventoryUI.activeInHierarchy == false)
        {
            inventoryUI.SetActive(true);
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
        else if (inventoryUI.activeInHierarchy == true)
        {
            speed = 0;
            animate.speed = 0;
        }
        else
        {
            speed = 4;
            animate.speed = 1;
        }
    }

    public void interact()
    {
        if (Input.GetKeyDown(KeyCode.F) && pickingUp == false && crouching != true)
        {
            if (closeToKey)
            {
                keys += 1;
                animate.SetTrigger("PickUpStand");
                pickingUp = true;
                Destroy(currentItem);
                Instantiate(key, position1.position, position1.rotation, position1.transform);
                if (keys == 2)
                {
                    Instantiate(key, position2.position, position2.rotation, position2.transform);
                }
                
            }
            else if (closeToLockedDoor)
            {
                currentItem.GetComponent<Doors>().unlockDoor(this);
            }
        }

        if (pickingUp)
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
    public void pickedUp()
    {
        pickingUp = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            currentItem = collision.gameObject;
            closeToKey = true;
        }

        if (collision.gameObject.tag == "LockedDoor")
        {
            currentItem = collision.gameObject;
            closeToLockedDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            currentItem = null;
            closeToKey = false;
        }

        if (collision.gameObject.tag == "LockedDoor")
        {
            currentItem = null;
            closeToLockedDoor = false;

        }
    }


}

