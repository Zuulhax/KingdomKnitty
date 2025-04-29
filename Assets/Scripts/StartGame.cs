/*****************************************************************************
// File Name : StartGame.cs
// Author : Hunter A. Breitenstein
// Creation Date : March 31, 2025
//
// Brief Description : This script allows the player to interact with the start button to start the game.
*****************************************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    /// <summary>
    /// Allows the player to start the game
    /// </summary>
    public void StartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
