using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject settingsMenu;
    [SerializeField]
    private GameObject[] settingButtons;
    private bool isPaused;

   public void OnClickPauseMenu()
   {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
            settingsMenu.GetComponent<Image>().color = new Color(0, 0, 0, 255);
            for(int i = 0; i < settingButtons.Length; i++)
            {
                settingButtons[i].SetActive(true);
            }

        }

        else
        {
            isPaused = false;
            Time.timeScale = 1;
            settingsMenu.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            for (int i = 0; i < settingButtons.Length; i++)
            {
                settingButtons[i].SetActive(false);
            }
        } 
   }
}
