/*****************************************************************************
// File Name : PlayerController.cs
// Author : Hunter A. Breitenstein
// Creation Date : March 27, 2025
//
// Brief Description : This script allows the player to control the character. It also allows the player to kill
// enemies. finally, it controlls when the KillEnemy sound plays
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
    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private AudioSource KillEnemy;
    [SerializeField] private float jumpValue = 7f;
    [SerializeField] private float jumpCooldown = 1f;

    private Rigidbody rb;
    private bool isGrounded = true;
    private float jumpTimer = 0f;
    private Vector3 playerMovement;

    /// <summary>
    /// enables the action map
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput.currentActionMap.Enable();

        SetupActions();
    }

    /// <summary>
    /// This is where the actions are located in the action map
    /// </summary>
    private void SetupActions()
    {
        restart = playerInput.currentActionMap.FindAction("Restart");
        quit = playerInput.currentActionMap.FindAction("Quit");

        restart.performed += Restart_performed;
        quit.performed += Quit_performed;
    }

    /// <summary>
    /// This performs quit
    /// </summary>
    /// <param name="context"></param>
    private void Quit_performed(InputAction.CallbackContext context)
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    /// <summary>
    /// This performs restart
    /// </summary>
    /// <param name="context"></param>
    private void Restart_performed(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// ends the action(s) of quit and restart
    /// </summary>
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
        if (jumpTimer <= 0 && isGrounded)
        {
            rb.velocity = new Vector3(0, jumpValue, 0);
            jumpTimer = jumpCooldown;
        }
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
    void Update()
    {
        rb.velocity = new Vector3(playerMovement.x, rb.velocity.y, playerMovement.z);

        if (jumpTimer > 0)
        {
            jumpTimer -= Time.deltaTime;
        }

        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
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
