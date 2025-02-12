using UnityEngine;

public class EndGameScene : MonoBehaviour
{
    public void resetGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
    }
}
