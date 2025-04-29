/*****************************************************************************
// File Name : EndScript.cs
// Author : Hunter A. Breitenstein
// Creation Date : April 17, 2025
//
// Brief Description : This script exits the game when the "Quit" button on screen is pressed
*****************************************************************************/

using UnityEngine;

public class EndScript : MonoBehaviour
{
    /// <summary>
    /// Exits the game when the button saying "Quit" is pressed
    /// </summary>
    public void EndGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;

        if (Application.isPlaying)
        {
            Application.Quit();
        }
    }
}
