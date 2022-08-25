using UnityEngine;

public class HidingSpot : MonoBehaviour
{




    bool close;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (close && Movement.crouching)
        {

            Movement.hidden = true;

        }
        else if(close &&  Movement.crouching != true)
        {
            Movement.hidden = false;

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
            Movement.hidden = false;

        }
    }
}
