using UnityEngine;
using UnityEngine.SceneManagement;

public class UserDetailsUI : MonoBehaviour
{
    private SceneTransitionManager transitionManager;

    private int sceneIndex;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void SignOut()
    {
        transitionManager.GoToScene(sceneIndex - 1);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
