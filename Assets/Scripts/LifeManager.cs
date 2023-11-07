using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public static LifeManager Instance;
    private int PlayerLife = 3;
    private TextMeshProUGUI PlayerLifeTMP;
    void Awake()
    {
        if (Instance != null && Instance != this){ 
            Destroy(this); 
        } else { 
            Instance = this; 
        }
    }

    private void Start() {
        GameObject PlayerLifeText = GameObject.FindWithTag("LifeText");
        PlayerLifeTMP = PlayerLifeText.GetComponent<TextMeshProUGUI>();
        PlayerLifeTMP.text = PlayerLife.ToString();
    }

   public void RemoveLife(){
        PlayerLife -= 1;
        PlayerLifeTMP.text = PlayerLife.ToString();
    }

    public int GetLifeCount(){
        return PlayerLife;
    }
}
