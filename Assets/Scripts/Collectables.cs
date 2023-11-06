using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] private GameObject nextLevel;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Player")){
            PointManager.Instance.AddItem();
            
            if(PointManager.Instance.GetItemCount() == 3){
                BoxCollider2D nextLevelCollider = nextLevel.GetComponent<BoxCollider2D>();
                nextLevelCollider.isTrigger = true;
            }

            Destroy(gameObject);
        }
    }
}
