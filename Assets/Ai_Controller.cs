using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    roaming, searching, chasing, catching 
}

public class Ai_Controller : MonoBehaviour
{
    public Sprite monsterAngry;
    public SpriteRenderer monsterRenderer;
    Animator animator;

    public EnemyState enemyState;
    public Transform eyes;

    [SerializeField]
    float speed;

    [SerializeField]
    public bool rightDirection;

    Rigidbody2D rb;


    Transform playerPosition;
    Transform lastPlayerPosition;
    float distance;
    float distanceX;


    // Start is called before the first frame update
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        monsterRenderer = gameObject.GetComponent<SpriteRenderer>();
         rb = gameObject.GetComponent<Rigidbody2D>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        distanceX = transform.position.x - playerPosition.position.x;

        if (distanceX < playerPosition.position.x)
        {
            rightDirection = true;
        }
        else
        {
            rightDirection = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector2.Distance(transform.position, playerPosition.position);

        RaycastHit2D hit = Physics2D.Raycast(eyes.position, -transform.right, 13);

        if(hit.collider != null)
        {
            if (hit.collider.tag == "Player" && Movement.hidden == false)
            {
                enemyState = EnemyState.chasing;
            }
        }
       

        effektDistanceMathf();

        if (enemyState == EnemyState.roaming)
        {
            animator.SetBool("Angry", false);

            if (rightDirection)
            {


                rb.velocity = new Vector2(speed, transform.position.y);
                transform.eulerAngles = new Vector3(0, 180, 0); // Flipped


            }
            else
            {
                rb.velocity = new Vector2(-speed, transform.position.y);
                transform.eulerAngles = new Vector3(0, 0, 0); // Flipped
            }


        }
        

        else if (enemyState == EnemyState.searching)
        {
            
        }
        else if (enemyState == EnemyState.chasing)
        {
            animator.SetBool("Angry", true);
            speed = 6.5f;
            rb.velocity = new Vector2(0, 0);
            monsterRenderer.sprite = monsterAngry;
           
            if(distance <= 7)
            {
                rb.velocity = new Vector2(0, 0);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPosition.position.x, transform.position.y), speed * Time.deltaTime);

            }
        }
        else if (enemyState == EnemyState.catching)
        {

        }







    }

    void effektDistanceMathf()
    {
       
        if (distance < 30)
        {
            MonsterEffect.monsterIsNear = true;
        }
        else
        {
            MonsterEffect.monsterIsNear = false;
        }
        if (distance >= 70)
        {
            Destroy(gameObject);
        }
    }
    
}
