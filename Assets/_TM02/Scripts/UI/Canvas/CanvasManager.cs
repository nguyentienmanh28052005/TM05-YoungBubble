using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Pixelplacement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : Singleton<CanvasManager>
{
    [Header("Canvas Main Menu")] 
    [SerializeField] private CanvasMenu CanvasMenu;    
    [SerializeField] private CanvasWin CanvasWin;
    [SerializeField] private PauseMenuCanvas CanvasPauseMenu;


    
    public Dictionary<string, CanvasBase> CanvasList = new Dictionary<string, CanvasBase>();
    
    public enum CurrentScene
    { 
        MAIN_MENU,
        GAME_PLAY
    }
    
    [Header("Something else")]
    public CurrentScene currentScene;
    public GameObject currentCanvas;

    public static bool isEscape = false;
    
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        HideChildren();
        StartCoroutine(AddCanvasToDict());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isEscape)
        {
            OpenCanvas("CanvasPauseMenu");
            isEscape = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isEscape)
        {
            Hide("CanvasPauseMenu");
            isEscape = false;
        }
    }

    private void HideChildren()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);  
        }
    }

    IEnumerator AddCanvasToDict()
    {
        yield return new WaitForSeconds(0.2f);
        CanvasList.Add(DefineValue.CANVAS_MENU, CanvasMenu);
        CanvasList.Add(DefineValue.CANVAS_WIN, CanvasWin);
        CanvasList.Add(DefineValue.CANVAS_PAUSEMENU, CanvasPauseMenu);


       
        // CanvasList[DefineValue.CANVAS_EXIT].Show();
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        HideChildren();
        string sceneName = scene.name;  // Get the name of the loaded scene

        // Choose and play the appropriate music based on sceneName
    }
    
    public void OpenCanvas(string a)
    {
        if (CanvasList.ContainsKey(a))
        {
            CanvasList[a].Show();
        }
        else
        {
            Debug.LogError("UIError: Canvas not found: " + a);
        }
    }

    public void Hide(string a)
    {
        if (CanvasList.ContainsKey(a))
        {
            CanvasList[a].Hide();
        }
        else
        {
            Debug.LogError("UIError: Canvas not found: " + a);
        }
    }
    
}
