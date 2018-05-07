using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {


	public static GameMaster gm;

	public Transform deathPoint;
	public Transform deathPrefab;

	public bool gameOver;


	// Use this for initialization
	void Start () {
			if (gm == null) {
  			gm = this;
 			}
	}

	public void KillPlayer()
	{

	}
	
}
