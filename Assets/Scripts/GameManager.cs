using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    void Start(){
        UpdateGameState(GameState.Menu);
    }

    void Awake()
    {
        if (Instance != null && Instance != this){ 
            Destroy(this); 
        } else { 
            Instance = this; 
        }
    }

    public void UpdateGameState(GameState newState){
        State = newState;

        switch(newState){
            case GameState.Menu:
                HandleMenu();
                break;
            case GameState.Play:
                HandlePlay();
                break;
            case GameState.Finish:
                HandleFinish();
                break;
            case GameState.Lose:
                HandleLose();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    //Handler kosong = di-handle oleh manager yang sudah subscribe dengan GameManager
    private void HandleMenu()
    {

    }

    private void HandlePlay()
    {
        GameObject canvas = GameObject.Find("Canvases");
        GameObject eventSystem = GameObject.Find("EventSystem");
        if(canvas != null && eventSystem != null){
            Destroy(canvas);
            Destroy(eventSystem);
        }
        LevelManager.Instance.StartGame();
    }

    private void HandleLose()
    {

    }

    private void HandleFinish()
    {
        GameObject canvas = GameObject.Find("Canvases");
        GameObject eventSystem = GameObject.Find("EventSystem");
        if(canvas != null && eventSystem != null){
            Destroy(canvas);
            Destroy(eventSystem);
        }
        LevelManager.Instance.LoadScene("Finish");
    }

    
}

public enum GameState {
    Menu,
    Play,
    Finish,
    Lose
}