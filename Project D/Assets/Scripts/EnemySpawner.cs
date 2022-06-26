using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] botReference;


    [SerializeField]
    private Transform leftPos, rightPos;

    private GameObject spawnedBot;

    private int randomIndex;

    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SpawnBots());
    }

    // Update is called once per frame
    IEnumerator SpawnBots()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = 0;
            randomSide = Random.Range(0, 2);

            spawnedBot = Instantiate(botReference[randomIndex]);

            if (randomSide == 0)
            {
                spawnedBot.transform.position = leftPos.position;
                spawnedBot.GetComponent<EnemyMovement>().speed = Random.Range(4, 7);
            }
            else
            {
                spawnedBot.transform.position = rightPos.position;
                spawnedBot.GetComponent<EnemyMovement>().speed = -Random.Range(4, 7);
                spawnedBot.transform.localScale = new Vector3(-0.5f, 0.3f, 1f);
            }
        } //while



    }
}
