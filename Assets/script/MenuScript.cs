using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void goToGame()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
    }
    
    public void goToGameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }
    
    public void goToCharacter()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CharacterSelect");
    }
    
    public void goToMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
}
