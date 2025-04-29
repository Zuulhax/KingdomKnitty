/*****************************************************************************
// File Name : ScoreController.cs
// Author : Hunter A. Breitenstein
// Creation Date : April 17, 2025
//
// Brief Description : This script controlls when score is added, when the coin is destroyed, how much is added to the
    score, and when the collect sound plays.
*****************************************************************************/

using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private AudioSource killSound;
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
