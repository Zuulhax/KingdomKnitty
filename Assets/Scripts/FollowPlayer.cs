/*****************************************************************************
// File Name : FollowPlayer.cs
// Author : Hunter A. Breitenstein
// Creation Date : March 27, 2025
//
// Brief Description : This script is to tell the camera to follow the player
*****************************************************************************/

using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;

    /// <summary>
    /// permanently set the cameras distance from the player
    /// </summary>
    void Start()
    {
        offset = new Vector3(0, 6, -8);
    }

    /// <summary>
    /// updates the cameras current position to match with the player
    /// </summary>
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
