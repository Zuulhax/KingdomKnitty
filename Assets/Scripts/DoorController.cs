/*****************************************************************************
// File Name : DoorController.cs
// Author : Hunter A. Breitenstein
// Creation Date : April 17, 2025
//
// Brief Description : This script sends the player to the next scene in the build index when they touch the door.
    It also plays a sound when you go through the door.
*****************************************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    [SerializeField] private AudioSource doorEnter;


    /// <summary>
    /// loads the next scene in the build index upon colliding with the door(s)
    /// </summary>
    /// <param name="collidedObject"></param>
    private void OnTriggerEnter(Collider collidedObject)
    {
        if (collidedObject.gameObject.name == "Player")
        {
            //load the next level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            doorEnter.Play();
        }
    }
}
