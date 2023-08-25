using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterRoom : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public bool playerInRange;
    public Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            //Debug.Log("Player in range");
            player = collision.GetComponent<Player>(); // Get a reference to the Player component
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            //Debug.Log("Player left range");
            player = null; // Reset the player reference when the player leaves the trigger area
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange && player != null)
        {


            SceneManager.LoadScene(sceneToLoad);

            //UpdateAnimation();

            print(player.facing);
        }
    }
}
