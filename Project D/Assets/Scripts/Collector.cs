using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private ScoreManager theScoreManager;

    private string PLAYER_TAG = "Player";

    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        
        if (collision.CompareTag(PLAYER_TAG))
        {
            theScoreManager.scoreIncreasing = false;
            Destroy(collision.gameObject);
        }
       
    }
}
