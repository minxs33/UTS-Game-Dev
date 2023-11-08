using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCheckpoint : MonoBehaviour
{
    public static LastCheckpoint Instance;
    public static Vector2 TempPlayerPos = new Vector2(0f,0.5f);
    void Awake(){
        if(Instance != null && Instance != this){
            Destroy(gameObject);
        }else{
            Instance = this;
        }
    }

    public static void SetPlayerPosition(Vector2 pos){
        TempPlayerPos = pos;
    }
    public static Vector2 GetPlayerPosition(){
        return TempPlayerPos;
    }
    
}
