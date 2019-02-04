using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCanvas2 : MonoBehaviour {
	GameObject J1name, IAname, pauUi, mpau, oscu, osce, begin;
	Image ioscu, iosce;
	Text tJ1name, tIAname;
	Fightinfo finfo; public bool pausa = false, instart = true;
	void Start () {
		begin = GameObject.Find("Begin");
		osce = GameObject.Find("Oscure");
		iosce = osce.GetComponent<Image>();
		oscu = GameObject.Find("Oscurecido2");
		ioscu = oscu.GetComponent<Image>();
		pauUi = GameObject.Find("PausaUI");
		mpau = GameObject.Find("MenuPausa");
		J1name = GameObject.Find("J1_name");
		IAname = GameObject.Find("IA_name");
		tJ1name = J1name.GetComponent<Text>();
		tIAname = IAname.GetComponent<Text>();
		finfo = GameObject.FindObjectOfType<Fightinfo>();
		pauUi.SetActive(false);
		mpau.SetActive(false);
		switch (finfo.luchadorJ1) {
			case 1: tJ1name.text = "Antman"; tJ1name.color = new Color(1.0f,0.37f,0.0f,1.0f); break;
			case 2: tJ1name.text = "Abominación"; tJ1name.color = new Color(0.4f,0.9f,0.0f,1.0f); break;
			case 3: tJ1name.text = "Thor"; tJ1name.color = new Color(0.92f,0.9f,0.0f,1.0f); break;
			case 4: tJ1name.text = "Ultron"; tJ1name.color = new Color(0.5f,0.0f,1.0f,1.0f); break;
			case 5: tJ1name.text = "Bucky"; tJ1name.color = new Color(0.05f,0.2f,0.4f,1.0f); break;
			case 6: tJ1name.text = "Deadpool"; tJ1name.color = new Color(0.5f,0.1f,0.1f,1.0f); break;
			case 7: tJ1name.text = "Ironman"; tJ1name.color = new Color(0.0f,0.25f,1.0f,1.0f); break;
			case 8: tJ1name.text = "Venom"; tJ1name.color = new Color(0.15f,0.3f,0.2f,1.0f); break;
		}
		switch (finfo.luchadorIA) {
			case 1: tIAname.text = "Antman"; tIAname.color = new Color(1.0f,0.37f,0.0f,1.0f); break;
			case 2: tIAname.text = "Abominación"; tIAname.color = new Color(0.4f,0.9f,0.0f,1.0f); break;
			case 3: tIAname.text = "Thor"; tIAname.color = new Color(0.92f,0.9f,0.0f,1.0f); break;
			case 4: tIAname.text = "Ultron"; tIAname.color = new Color(0.5f,0.0f,1.0f,1.0f); break;
			case 5: tIAname.text = "Bucky"; tIAname.color = new Color(0.05f,0.2f,0.4f,1.0f); break;
			case 6: tIAname.text = "Deadpool"; tIAname.color = new Color(0.5f,0.1f,0.1f,1.0f); break;
			case 7: tIAname.text = "Ironman"; tIAname.color = new Color(0.0f,0.25f,1.0f,1.0f); break;
			case 8: tIAname.text = "Venom"; tIAname.color = new Color(0.15f,0.3f,0.2f,1.0f); break;
		}
		StartCoroutine("Stari");
	}
	public void Reanudar(){
		mpau.SetActive(false);
		pauUi.SetActive(false);
		pausa = false;
	}
	void Update () {
		if (Input.GetButtonUp("Pausa")) {
			Pausa();
        }
	}
	IEnumerator Stari(){
	    float transparencia = 0.6f;
		for (int i = 0; i < 15; i++){
			transparencia = transparencia - 0.04f;
			iosce.color = new Color(0.0f, 0.0f, 0.0f, transparencia);
			yield return new WaitForSeconds(0.125f);
		}
		begin.SetActive(false);
		osce.SetActive(false);
		instart = false;
	}
	IEnumerator Pausar(){
		float color = 1.0f, transparencia = 0.0f;
		for (int i = 0; i < 10; i++){
			color = color - 0.1f;
			transparencia = transparencia + 0.04f;
			ioscu.color = new Color(color, color, color, transparencia);
			yield return new WaitForSeconds(0.125f);
		}
		ioscu.color = new Color(0.0f,0.0f,0.0f,0.412f);
		mpau.SetActive(true);
	}
	public void Pausa(){
		pausa = true;
		StartCoroutine("Pausar");
		pauUi.SetActive(true);
	}
}
