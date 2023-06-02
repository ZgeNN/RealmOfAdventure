using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    
    public void GameOver()
    {
        Debug.Log("Game Over");
        GetComponent<PlayerMovement>().enabled = false;
        gameOverPanel.SetActive(true);
    }
}
