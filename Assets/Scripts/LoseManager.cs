using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoseManager : MonoBehaviour
{
    public static LoseManager Instance;
    private GameObject restartMenuPanel, restartButton, statsMenuCanvas;

    void Awake(){ 
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    void OnDestroy() {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        if(state == GameState.Lose){
            GameObject parentGameObject = GameObject.Find("Canvases");
            Transform loseCanvas = parentGameObject.transform.Find("LoseCanvas"); 
            restartMenuPanel = loseCanvas.transform.Find("RestartMenu").gameObject;

            restartButton = restartMenuPanel.transform.Find("RestartButton").gameObject;
            Button btnRestart = restartButton.GetComponent<Button>();
            btnRestart.onClick.AddListener(Restart);

            Transform canvas = parentGameObject.transform.Find("Canvas");
            statsMenuCanvas = canvas.gameObject;
            
            restartMenuPanel.SetActive(true);
            statsMenuCanvas.SetActive(false);
        }
        
        Debug.Log(state);
    }

    private void Restart(){
        GameManager.Instance.UpdateGameState(GameState.Play);
        Debug.Log("clicked");
    }
}
