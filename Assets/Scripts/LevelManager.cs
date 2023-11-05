using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance;
    private Animator _playerAnimator;
    private GameObject Player;

    void Awake()
    {
        if(Instance == null){
            Instance = this;
        }else{
            Destroy(gameObject);
        }
    }

    public void StartGame(){
        SceneManager.LoadSceneAsync("GameScene");
    }
    
    public async void LoadScene(string sceneName) {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        // non-aktif movement dan animasi
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.GetComponent<CharacterMovement>().enabled = false;
        Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        
        _playerAnimator = Player.GetComponent<Animator>();
        _playerAnimator.enabled = false;
    
        await Task.Delay(500);
        scene.allowSceneActivation = true;
    }

}
