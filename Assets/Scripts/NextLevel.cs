using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private string text;
    [SerializeField] bool isTumang;
    private GameObject canvases, alertCanvas;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Player")){
            LastCheckpoint.SetPlayerPosition(new Vector2(0f,0f));
            LevelManager.Instance.LoadScene(sceneName);
        }
    }

    private void FindCanvas() {
        // mencari direktori text AlertCanvas
        canvases = GameObject.Find("Canvases");
        Transform canvas = canvases.transform.Find("Canvas");
        alertCanvas = canvas.Find("AlertCanvas").gameObject;

        Transform tumang = alertCanvas.transform.Find("tumang");
        Transform dayangSumbi = alertCanvas.transform.Find("dayangSumbi");
        if(isTumang){
            
            dayangSumbi.gameObject.SetActive(false);
            tumang.gameObject.SetActive(true);
        }else{  
            dayangSumbi.gameObject.SetActive(true);
            tumang.gameObject.SetActive(false);
        }

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
