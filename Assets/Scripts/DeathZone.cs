using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Player")){
            LifeManager.Instance.RemoveLife();
            Destroy(other.gameObject);

            if(LifeManager.Instance.GetLifeCount() > 0){
                PlayerRespawn.Instance.Respawn();
            }
        }
    }
    void Update()
    {
        
    }
}