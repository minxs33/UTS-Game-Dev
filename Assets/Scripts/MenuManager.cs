using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenuPanel;
    [SerializeField] private Button startButton;
    void Awake(){ 
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    void OnDestroy() {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        startMenuPanel.SetActive(state == GameState.Menu);
    }

    void Start()
    {
        Button btnStart = startButton.GetComponent<Button>();
        btnStart.onClick.AddListener(Play);
    }

    void Play(){
        GameManager.Instance.UpdateGameState(GameState.Play);
    }

}
