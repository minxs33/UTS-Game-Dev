using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public static PointManager Instance;
    private int itemCollected;
    private int life;
    void Awake()
    {
        if (Instance != null && Instance != this){ 
            Destroy(this); 
        } else { 
            Instance = this; 
        }
    }
    
    public void AddItem(){
        itemCollected += 1;
    }

    public int GetItemCount(){
        return itemCollected;
    }
}
