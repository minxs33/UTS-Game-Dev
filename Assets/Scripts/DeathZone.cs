using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Player")){
            LifeManager.Instance.RemoveLife();
            Destroy(other.gameObject);

            if(LifeManager.Instance.GetLifeCount() > 0){
                PlayerRespawn.Instance.Respawn();
            }else{
                GameManager.Instance.UpdateGameState(GameState.Lose);
                // Debug.Log(GameState.Lose);
            }
        }
    }
}
