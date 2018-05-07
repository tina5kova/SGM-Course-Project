using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

	public GameObject gameManager;
	public GameObject victoryUI;
	public GameObject gameOverUI;
	// Use this for initialization
	void Start () {
		if(GameMaster.instance==null)
		{
			GameObject gm = Instantiate<GameObject>(gameManager);
			gm.GetComponent<GameMaster>().setVictoryUI(victoryUI);
			gm.GetComponent<GameMaster>().setGameOverUI(gameOverUI);
		}
	}
	
}
