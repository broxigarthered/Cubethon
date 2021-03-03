using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.LogFormat("We hit something {0}", collision.collider.name);

        if (collision.collider.CompareTag("Obstacle"))
        {
            Debug.Log("We hit an obstacle!!");

            playerMovement.enabled = false;

            FindObjectOfType<GameManager>().EndGame();
            
        } else if (collision.collider.CompareTag("Finish"))
        {

            // SAME
            //GetComponent<PlayerMovement>().enabled = false;

            playerMovement.enabled = false;

            FindObjectOfType<GameManager>().EndGame();
        }

    }
}
