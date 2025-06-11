using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginUI : MonoBehaviour
{
    private SceneTransitionManager transitionManager;

    private int sceneIndex;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void Login()
    {
        transitionManager.GoToScene(sceneIndex + 1);
    }
}
