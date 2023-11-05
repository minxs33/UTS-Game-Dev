using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseManager : MonoBehaviour
{

    [SerializeField] private GameObject restartMenuPanel, statsMenuCanvas;
    [SerializeField] private Button restartButton;

    void Awake(){ 
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    void OnDestroy() {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        restartMenuPanel.SetActive(state == GameState.Lose);
        statsMenuCanvas.SetActive(false);
    }
    void Start()
    {
        Button btnRestart = restartButton.GetComponent<Button>();
        btnRestart.onClick.AddListener(Restart);
    }

     void Restart(){
        GameManager.Instance.UpdateGameState(GameState.Play);
    }
}
