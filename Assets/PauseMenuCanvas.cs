using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuCanvas : CanvasBase
{
    public override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void Reset()
    {
        SceneManager.LoadScene("GamePlayScene");
        Time.timeScale = 1;
        CanvasManager.isEscape = false;
    }
    
    public void OutGame()
    {
        SceneManager.LoadScene("StartGameScene");
        Time.timeScale = 1;
        CanvasManager.isEscape = false;
    }
}
