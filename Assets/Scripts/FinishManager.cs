using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishManager : MonoBehaviour
{
    [SerializeField] private GameObject button;
    void Start()
    {
        Button btnRestart = button.GetComponent<Button>();
        btnRestart.onClick.AddListener(Restart);
    }

    void Restart()
    {
        GameManager.Instance.UpdateGameState(GameState.Play);
    }
}
