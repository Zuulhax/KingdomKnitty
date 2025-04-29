/*****************************************************************************
// File Name : PlayerLife.cs
// Author : Hunter A. Breitenstein
// Creation Date : March 27, 2025
//
// Brief Description : This script is to tell the player to die upon contact with an enemy, and respawn after a brief
// period of time. It also plays a sound when the player dies.
*****************************************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    [SerializeField] private float loadDelay = 1.5f;
    [SerializeField] private int dyingYValue = -2;
    [SerializeField] private AudioSource deadSound;

    private bool isDead = false;

    /// <summary>
    /// stops everything related to the player upon death
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            //make the player invisible
            GetComponent<MeshRenderer>().enabled = false;

            //player can no longer move
            GetComponent<PlayerController>().enabled = false;

            //stop responding to physics (gravity)
            GetComponent<Rigidbody>().isKinematic = false;

            Die();
        }
    }

    /// <summary>
    /// initiates the reload of the scene upon death
    /// </summary>
    private void Die()
    {
        isDead = true;
        deadSound.Play();

        Invoke("ReloadScene", loadDelay);
    }

    /// <summary>
    /// reloads the scene upon death
    /// </summary>
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// DIE!
    /// </summary>
    void Update()
    {
        if (transform.position.y < dyingYValue && !isDead)
        {
            //DIE!
            Die();
        }
    }
}
