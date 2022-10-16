using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;
    // fade animator
    #region fading

    [SerializeField]
    private CanvasGroup sceneFader;
    [SerializeField]
    private float FadeINVelocity;
    [SerializeField]
    private float FadeOutVelocity;

    public bool fadeIn;
    [System.NonSerialized] public bool fadeOut;

    #endregion

    private void Start()
    {
        fadeOut = true;
    }

    private void Update()
    {
        if (fadeIn)
        {
            FadeIn();
        }

        if (fadeOut)
        {
            FadeOut();
        }
    }

    public void LoadScene()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(this.sceneToLoad);
    }

    public void FadeIn()
    {
        sceneFader.alpha += (Time.deltaTime * FadeINVelocity);

        if (sceneFader.alpha >= 1)
        {
            LoadScene();
        }
    }

    public void FadeOut()
    {
        sceneFader.alpha -= (Time.deltaTime * FadeOutVelocity);

        if (sceneFader.alpha <= 0)
        {
            fadeOut = false;
        }
    }
}
