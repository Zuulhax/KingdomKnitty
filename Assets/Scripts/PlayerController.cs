/*****************************************************************************
// File Name : PlayerController.cs
// Author : Hunter A. Breitenstein
// Creation Date : March 27, 2025
//
// Brief Description : This script allows the player to control the character. It also allows the player to kill
// enemies.
*****************************************************************************/

using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private InputAction quit;
    [SerializeField] private InputAction restart;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private AudioSource KillEnemy;

    private Rigidbody _rb;

    private Vector3 playerMovement;

    /// <summary>
    /// enables the action map
    /// </summary>
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        playerInput.currentActionMap.Enable();

        SetupActions();
    }

    private void SetupActions()
    {
        restart = playerInput.currentActionMap.FindAction("Restart");
        quit = playerInput.currentActionMap.FindAction("Quit");

        restart.performed += Restart_performed;
        quit.performed += Quit_performed;
    }

    private void Quit_performed(InputAction.CallbackContext context)
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    private void Restart_performed(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(1);
    }

    private void OnDestroy()
    {
        restart.performed -= Restart_performed;
        quit.performed -= Quit_performed;
    }

    /// <summary>
    /// Called by Unity, not by code
    /// moves the player vertically
    /// </summary>
    private void OnJump(InputValue value)
    {
        _rb.velocity = new Vector3(0, jumpForce, 0);
    }

    /// <summary>
    /// Gets the value from the keyboard and updates the movement variable
    /// </summary>
    /// <param name="iValue">value read in</param>
    private void OnMove(InputValue iValue)
    {
        Vector2 inputMovementValue = iValue.Get<Vector2>();
        playerMovement.x = inputMovementValue.x * playerSpeed;
        playerMovement.z = inputMovementValue.y * playerSpeed;
    }

    /// <summary>
    /// updates the players movement every frame
    /// </summary>
    private void Update()
    {
        _rb.velocity = new Vector3(playerMovement.x, _rb.velocity.y, playerMovement.z);
    }

    /// <summary>
    /// Destroys enemy upon its death
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        //if the player collides (jumps on) the enemy's head
        if (collision.gameObject.CompareTag("EnemyHead"))
        {
            KillEnemy.Play();

            //destroy the parent aka the enemy
            Destroy(collision.transform.parent.gameObject);
        }
    }
}
