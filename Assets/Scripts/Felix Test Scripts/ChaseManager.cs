using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseManager : MonoBehaviour
{
    [Header("Game objects to be en/disabled")]
    [SerializeField] private GameObject[] startEnable;
    [SerializeField] private GameObject[] startDisable;

    [SerializeField] private GameObject[] endEnable;
    [SerializeField] private GameObject[] endDisable;

    [Header("Custom info needed")]
    [SerializeField] private float numOfWagons = 3f;
    [SerializeField] private float wagonLength = 18.25f;

    public void BeginChase(GameObject player)
    {
        // Moves this to the end trigger location
        transform.Translate(Vector3.right * wagonLength);

        // Encapsulated section to enable and disable objects
        {
            // Enables new objects
            for (int i = 0; i < startEnable.Length; i++)
            {
                startEnable[i].SetActive(true);
            }

            // Disables old objects
            for (int i = 0; i < startDisable.Length; i++)
            {
                startDisable[i].SetActive(false);
            }
        }

        // Sends the chase manager into the wagon to the right, makes it an end trigger instead

        // Sends player to the new end wagon
        player.transform.Translate(Vector3.right * wagonLength * numOfWagons);

        // Add piece of code to summon monster to the left and some spook to make you wanna run to the right
    }

    public void EndChase()
    {
        // Encapsulated section to enable and disable objects
        {
            // Enables new objects
            for (int i = 0; i < endEnable.Length; i++)
            {
                endEnable[i].SetActive(true);
            }

            // Disables old objects
            for (int i = 0; i < endDisable.Length; i++)
            {
                endDisable[i].SetActive(false);
            }
        }

        // Would perhaps run some special code here
    }
}
