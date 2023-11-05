using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.Mathematics;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public static PlayerRespawn Instance;
    [SerializeField] CinemachineVirtualCamera _virtualCamera;
    private Vector2 playerPosition;
    [SerializeField] GameObject Player;
    
     void Awake()
    {
        if (Instance != null && Instance != this){ 
            Destroy(this); 
        } else { 
            Instance = this; 
        }
    }

    public void Respawn()
    {
        playerPosition = LastCheckpoint.GetPlayerPosition();
        if(Player != null){
            StartCoroutine(Delay(playerPosition));
        }else{
            Debug.LogError("Player Prefabs tidak terinisiasi di inspector");
        }
        
    }

    private IEnumerator Delay(Vector2 pos){
        yield return new WaitForSeconds(1.0f);

        GameObject playerPrefabs = Instantiate(Player, pos, quaternion.identity);
        playerPrefabs.transform.SetParent(gameObject.transform, false);
        playerPrefabs.name = playerPrefabs.name.Replace("(Clone)", "");
            if (playerPrefabs != null)
            {
                _virtualCamera.GetComponent<CinemachineVirtualCamera>().Follow = playerPrefabs.transform;
            }else{
                Debug.LogError("Virtual Camera tidak terinisiasi atau Player Prefabs tidak ter-instantiate");
            }
    }
}
