using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public static PointManager Instance;
    private int itemCollected = 0;
    private int itemObjective = 0;
    public TextMeshProUGUI itemCollectedText;
    void Awake()
    {
        if (Instance != null && Instance != this){ 
            Destroy(this); 
        } else { 
            Instance = this; 
        }
    }

    private void Start() {
        itemCollectedText.text = itemCollected.ToString()+" / "+itemObjective.ToString();
    }

    public void SetText() {
        itemCollectedText.text = itemCollected.ToString()+" / "+itemObjective.ToString();
    }
    
    public void AddItem(){
        itemCollected += 1;
        itemCollectedText.text = itemCollected.ToString()+" / "+itemObjective.ToString();
    }

    public int GetItemCount(){
        return itemCollected;
    }

    public void SetItemObjective(int total){
        itemObjective = total;
    }

    public int GetItemObjectiveCount(){
        return itemObjective;
    }
}
