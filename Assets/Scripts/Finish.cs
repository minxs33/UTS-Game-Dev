using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private string text;
    private GameObject canvases, alertCanvas;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Player")){
            GameManager.Instance.UpdateGameState(GameState.Finish);
        }
    }

    private void FindCanvas() {
        canvases = GameObject.Find("Canvases");
        Transform canvas = canvases.transform.Find("Canvas");
        alertCanvas = canvas.Find("AlertCanvas").gameObject;
        Transform alertCanvasText = alertCanvas.transform.Find("text");
        TextMeshProUGUI alertText = alertCanvasText.GetComponent<TextMeshProUGUI>();
        alertText.text = text;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Player")){
            FindCanvas();
            alertCanvas.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.transform.CompareTag("Player")){
            alertCanvas.SetActive(false);
        }
    }
}
