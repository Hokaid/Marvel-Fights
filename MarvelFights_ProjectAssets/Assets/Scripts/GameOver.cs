using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	void Start () {
		
	}
	void Update () {
		
	}
	public void VolverPelear(){
		SceneManager.LoadScene("Fight");
	}
	public void SeleccionarPersonajes(){
		SceneManager.LoadScene("Selec");
	}
	public void MenuPrincipal(){
		SceneManager.LoadScene("Menu");
	}
}
