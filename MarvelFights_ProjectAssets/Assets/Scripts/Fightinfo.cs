using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fightinfo : MonoBehaviour {
	public int dificultad, luchadorIA, luchadorJ1, escenario;
	void Start () {
	}
	void Awake(){
		DontDestroyOnLoad(gameObject);
	}
	void Update () {}
}
