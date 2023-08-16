using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public string sceneName;
    
    public void OpenScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
