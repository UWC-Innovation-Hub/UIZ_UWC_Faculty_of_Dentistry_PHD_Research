using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField] private FadeScreen fadeScreen;
    [SerializeField] private LoginUI loginUI;

    private void OnEnable()
    {
        loginUI.OnLogin += OnLoginButtonPressed;
    }

    private void OnDisable()
    {
        loginUI.OnLogin -= OnLoginButtonPressed;
    }

    private void OnLoginButtonPressed()
    {
        GoToScene(0);
    }

    public void GoToScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }

    private IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        fadeScreen.FadeOut();

        // Launch new scene
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        float timer = 0;
        while(timer <= fadeScreen.fadeDuration && !operation.isDone)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        operation.allowSceneActivation = true;
    }
}
