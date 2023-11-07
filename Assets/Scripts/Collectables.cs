using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] private GameObject referenceCollider;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Player")){
            PointManager.Instance.AddItem();
            
            if(PointManager.Instance.GetItemCount() == PointManager.Instance.GetItemObjectiveCount()){
                BoxCollider2D Collider = referenceCollider.GetComponent<BoxCollider2D>();
                Collider.isTrigger = true;
            }
            Destroy(gameObject);
        }
    }
}
