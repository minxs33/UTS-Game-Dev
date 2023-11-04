using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Player")){
            PointManager.Instance.AddItem();
            Destroy(gameObject);
        }
    }
}
