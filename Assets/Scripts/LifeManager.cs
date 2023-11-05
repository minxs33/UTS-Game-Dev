using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public static LifeManager Instance;
    private int PlayerLife = 3;
    public TextMeshProUGUI PlayerLifeText;
    void Awake()
    {
        if (Instance != null && Instance != this){ 
            Destroy(this); 
        } else { 
            Instance = this; 
        }
    }

    private void Start() {
        PlayerLifeText.text = PlayerLife.ToString();
    }

   public void RemoveLife(){
        PlayerLife -= 1;
        PlayerLifeText.text = PlayerLife.ToString();
    }

    public int GetLifeCount(){
        return PlayerLife;
    }
}
