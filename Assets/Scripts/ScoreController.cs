using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private AudioSource collectSound;
    //[SerializeField] private AudioSource killSound;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void OnTriggerEnter(Collider thingIHit)
    {
        //if I hit (collided with) a coin
        if(thingIHit.gameObject.CompareTag("Coin"))
        {
            //update the score
            score += 5;

            collectSound.Play();

            UpdateScore();

            //destroy aka collect the coin
            Destroy(thingIHit.gameObject);
        }

        if(thingIHit.gameObject.CompareTag("EnemyHead"))
        {
            //update score
            score += 10;

            //killSound.Play();

            UpdateScore();

            //destroy aka kill the enemy
            Destroy(thingIHit.gameObject);
        }
    }
}
