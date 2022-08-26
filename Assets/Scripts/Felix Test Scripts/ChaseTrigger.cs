using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTrigger : MonoBehaviour
{
    [SerializeField] private ChaseManager chaseManager;
    [SerializeField] private bool isStartTrigger = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (isStartTrigger)
            {
                chaseManager.BeginChase(collision.gameObject);
            }
            else
            {
                chaseManager.EndChase();
            }
        }
    }
}
