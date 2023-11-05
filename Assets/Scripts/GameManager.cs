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

    void Awake(){
        Instance = this;
        if(Instance == null){
            Instance = this;
        }else{
            Destroy(gameObject);
        }
    }

    public void UpdateGameState(GameState newState){
        State = newState;

        switch(newState){
            case GameState.Menu:
                HandleMenu();
                break;
            case GameState.Victory:
                break;
            case GameState.Lose:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleMenu()
    {
        
    }
}

public enum GameState {
    Menu,
    Victory,
    Lose
}