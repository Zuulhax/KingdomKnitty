/*****************************************************************************
// File Name : Rotate.cs
// Author : Hunter A. Breitenstein
// Creation Date : April 17, 2025
//
// Brief Description : This script constantly rotates the coins
*****************************************************************************/

using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float xSpeed;
    [SerializeField] private float ySpeed;
    [SerializeField] private float zSpeed;

    /// <summary>
    /// rotate the coins on either the x, y, or z axis
    /// </summary>
    void Update()
    {
        transform.Rotate(360 * xSpeed * Time.deltaTime, 360 * ySpeed * Time.deltaTime, 360 * zSpeed * Time.deltaTime); 
    }
}
