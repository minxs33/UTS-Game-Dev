using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject itemStatusCanvas;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Player")){
            LevelManager.Instance.LoadScene(sceneName);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Player")){
            itemStatusCanvas.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.transform.CompareTag("Player")){
            itemStatusCanvas.SetActive(false);
        }
    }
}
