using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance = null;
    [SerializeField] private GameObject victoryUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject canvas;
    private EnemyHealth enemyHealth;
    public bool gameOver;


    void Start()
    {
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("Player")) {
			go.GetComponent<PlayerHealth>().OnDied += handleGameOver;
		}
        
        
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>().playerVictoryAction += VictoryOver;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
       
    }

    public void VictoryOver()
    {
        Debug.Log("Victory!" + (victoryUI != null));
		victoryUI.SetActive(true);  
    }

    public void handleGameOver()
    {
        Debug.Log("Game Over!"+ (gameOverUI != null));
		gameOverUI.SetActive(true);
    }

    public void setVictoryUI(GameObject go)
    {
        victoryUI = go;	
    }
	 public void setGameOverUI(GameObject go)
    {
        gameOverUI = go;	
    }
}
