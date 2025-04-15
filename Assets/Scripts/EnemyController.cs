/*****************************************************************************
// File Name : EnemyController.cs
// Author : Hunter A. Breitenstein
// Creation Date : March 27, 2025
//
// Brief Description : This script is to tell the enemies to always follow the player.
*****************************************************************************/

using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;

    /// <summary>
    /// checks the current position, and follows them around the level
    /// </summary>
    void Update()
    {
        if (player != null) // Check if the player GameObject is assigned
        {
            // Calculate the direction from the enemy to the player
            Vector3 direction = (player.transform.position - transform.position).normalized;

            // Move the enemy towards the player
            transform.Translate(speed * Time.deltaTime * direction);
        }
    }
}
