using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public TextMeshProUGUI Game;

    public void Restart()
    {
         SceneManager.LoadScene("Level01");
        
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("Levels");
    }
}
