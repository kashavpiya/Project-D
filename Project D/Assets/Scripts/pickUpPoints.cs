using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpPoints : MonoBehaviour
{

    public int scorePerGem;

    private ScoreManager theScoreManager;

    private string PLAYER_TAG = "Player";

    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(PLAYER_TAG))
        {
            theScoreManager.AddPoints(scorePerGem);
            Destroy(gameObject);
        }
    }
}
