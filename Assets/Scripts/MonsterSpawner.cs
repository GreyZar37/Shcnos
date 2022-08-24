using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public Transform[] spawners;
    public GameObject Train;


    // Start is called before the first frame update
    void Start()
    {
       
            StartCoroutine(spawnMonster());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnMonster()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(20, 40));

            Instantiate(monsterPrefab, spawners[Random.Range(0, spawners.Length)].position, Quaternion.identity, Train.transform);
        }
       


    }
}
