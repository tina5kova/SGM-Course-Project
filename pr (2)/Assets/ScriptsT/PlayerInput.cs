using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerInput : MonoBehaviour {
public int playerNumber;
public float Horizontal { get; set; }
public bool Jump { get; set; }
public bool IsAttacking { get; set; }

public event Action OnAttack=delegate{};

	
	
	void Update () {
		IsAttacking= (Input.GetButtonDown("Fire1Pl"+playerNumber));
		if(IsAttacking)
		OnAttack();
		
		
		Horizontal = Input.GetAxis("HorizontalPl"+playerNumber);
		Jump = Input.GetButtonDown("JumpPl"+playerNumber);
		
	}
}