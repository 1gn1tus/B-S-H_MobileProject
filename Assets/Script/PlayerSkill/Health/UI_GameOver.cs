using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UI_GameOver : MonoBehaviour
{
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
        setFreezeTime();
    }

    public void setFreezeTime()
    {
        Time.timeScale = 0;
    }

    public void RestartLevelButton()
    {
        SceneManager.LoadScene(playerHealth.currentLevel);
    }
}
