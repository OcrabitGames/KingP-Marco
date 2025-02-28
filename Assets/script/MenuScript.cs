using System.Collections;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void goToGame()
    {
        StartCoroutine(WaitForSoundAndTransition("MainGame"));
    }
    
    // Sorry for the comment below \/ The ide got mad
    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator WaitForSoundAndTransition(string sceneName){
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
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
