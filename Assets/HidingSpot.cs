using UnityEngine;

public class HidingSpot : MonoBehaviour
{

    public GameObject playerHidden;
    public SpriteRenderer objSpr;


    public SpriteRenderer player;

    bool hidden;
    bool close;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
       
        if (close && Input.GetKeyDown(KeyCode.F))
        {
            if (hidden)
            {
                Movement.hidden = false;

                hidden = false;
                playerHidden.SetActive(false);
                player.enabled = true;
            }
            else if (hidden == false)
            {
                Movement.hidden = true;
                hidden = true;
                playerHidden.SetActive(true);
                player.enabled = false;
            }
        }
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            close = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            close = false;
        }
    }
}
