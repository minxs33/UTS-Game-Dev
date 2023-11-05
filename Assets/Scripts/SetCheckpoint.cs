using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCheckpoint : MonoBehaviour
{
    private SpriteRenderer sp;
    private SpriteRenderer[] checkpoints;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Player")){
            LastCheckpoint.SetPlayerPosition(this.transform.localPosition);

            GameObject[] checkpointGameobjects = GameObject.FindGameObjectsWithTag("Checkpoint");
            checkpoints = new SpriteRenderer[checkpointGameobjects.Length];

            for (int i = 0; i < checkpointGameobjects.Length; i++){
                checkpoints[i] = checkpointGameobjects[i].GetComponent<SpriteRenderer>();

                if (checkpoints[i] != null)
                {
                    checkpoints[i].color = new Color(255, 0, 0, 255);
                }
            }

            sp = this.GetComponent<SpriteRenderer>();
            sp.color = new Color(0,255,53,255);
        }
    }
}
