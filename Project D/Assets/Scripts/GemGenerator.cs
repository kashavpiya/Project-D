using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] gemReference;

    private GameObject spawnedGem;

    private int randomX;

    private int randomIndex;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnGems());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnGems()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomX = Random.Range(-46, 66);

            randomIndex = Random.Range(0, 2);

            spawnedGem = Instantiate(gemReference[randomIndex]);

            spawnedGem.transform.position = new Vector3(randomX, -1, 0);
        }
        


    }
}
