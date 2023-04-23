using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_loader : MonoBehaviour
{
    int sceneno;
    //Scene currentscene;
    // private void start()
    //{
    //   currentscene = SceneManager.GetActiveScene();
    //  Debug.Log(currentscene.buildIndex);
    //}
    private void Start()
    {
        sceneno = 0;
    }
    public void playscene()
    {
        
            SceneManager.LoadScene(1);
            
       
    }
    public void pause()
    {
        Time.timeScale = 0f;
    }
    public void playG()
    {
        Time.timeScale = 1f;
    }
    public void startscene()
    {
        SceneManager.LoadScene(0);
    }
    public void exitgame()
    {
        Application.Quit();
    }
}
