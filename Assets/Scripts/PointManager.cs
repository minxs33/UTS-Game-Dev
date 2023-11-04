using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public static PointManager Instance;
    private int itemCollected = 0;
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
        itemCollectedText.text = itemCollected.ToString();
    }
    
    public void AddItem(){
        itemCollected += 1;
        itemCollectedText.text = itemCollected.ToString();
    }

    public int GetItemCount(){
        return itemCollected;
    }

    private void Update() {
        Debug.Log(itemCollected);
    }
}
