using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;

    bool gameHasEnded = false;
    public float restartDelay = 3f;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
        FindObjectOfType<PlayerMovement>().StopPlayerFromMoving();
    }

    public void EndGame()
    {
   
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");

            // TODO: Call this upon button click
            Invoke(nameof(Restart), restartDelay); 
        }
        
    }

    void Restart()
    {
        // this loads the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
