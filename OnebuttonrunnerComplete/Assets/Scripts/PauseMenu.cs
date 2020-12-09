using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused;  // Bool is declared as true   
    public GameObject pauseMenu;
    public bool ispaused = false;


    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    private void Update() {
    ScanForKeyStroke();
}

void ScanForKeyStroke()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            Debug.Log("a");
            if (ispaused == false)
            {
                Pause();
            }
            else
            {
                resume();
            }
            
	    }
        
    }

       public void Pause()
    {
        if(Time.timeScale == 0f)
        {
            Time.timeScale = 1f; 
        }
        else
        {
            Time.timeScale = 0f;
        }
        pauseMenu.SetActive(true);
        ispaused = true;

    }
    public void resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        ispaused = false;
    }
    
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
} 

      






