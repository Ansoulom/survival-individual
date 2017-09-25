using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneButton : MonoBehaviour
{
    public string Scene;

    
    public void StartGame()
    {
        SceneManager.LoadScene(Scene);
    }
}
