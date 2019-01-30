using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class EfectoPow : MonoBehaviour {
	public Sprite[] pows; GameObject pow1GO, altpowGO;
	Luchador1 luch1; LuchadorIA luchia; Controlador_de_barras cbarras;
	Transform pow1GOt, altpowGOt; Image pow1GOi, altpowGOi; bool Powie = false;
	AudioSource ausou; public AudioClip[] clips; CCanvas2 can2;
	void Start () {
		can2 = GameObject.FindObjectOfType<CCanvas2>();
		ausou = gameObject.GetComponent<AudioSource>();
		luch1 = GameObject.FindObjectOfType<Luchador1>();
		luchia = GameObject.FindObjectOfType<LuchadorIA>();
		pow1GO = GameObject.Find("Pow1");
		altpowGO = GameObject.Find("AltPow");
		pow1GOt = pow1GO.GetComponent<Transform>();
		altpowGOt = altpowGO.GetComponent<Transform>();
		pow1GOi = pow1GO.GetComponent<Image>();
		altpowGOi = altpowGO.GetComponent<Image>();
		cbarras = GameObject.FindObjectOfType<Controlador_de_barras>();
	}
	IEnumerator Pow(){
		altpowGOt.localScale = new Vector3(0.0f,0.0f,0.0f);
		pow1GOt.localScale = new Vector3(0.0f,0.0f,0.0f);
		for (int i = 0; i < 15; i++){
			altpowGOt.localScale = altpowGOt.localScale + new Vector3(0.1f,0.1f,0.0f); 
			pow1GOt.localScale = pow1GOt.localScale + new Vector3(0.1f,0.1f,0.0f); 
			yield return null;
		}
		yield return new WaitForSeconds(0.5f);
		for (int i = 0; i < 15; i++){
			altpowGOt.localScale = altpowGOt.localScale - new Vector3(0.1f,0.1f,0.0f); 
			pow1GOt.localScale = pow1GOt.localScale - new Vector3(0.1f,0.1f,0.0f); 
			yield return null;
		}
		altpowGOt.localScale = new Vector3(0.0f,0.0f,0.0f);
		pow1GOt.localScale = new Vector3(0.0f,0.0f,0.0f);
		pow1GOi.color = new Color(1.0f,1.0f,1.0f,0.0f);
		altpowGOi.color = new Color(1.0f,1.0f,1.0f,0.0f);
		Powie = false;
	}
	void Update () {
		if (Powie == false && cbarras.gameover == false && can2.pausa == false){
			if (luchia.golpeado == true){
				if (luch1.tipo_golpe == 1){
					pow1GOi.sprite = pows[0];
					altpowGOi.sprite = pows[2];
					ausou.clip = clips[0];
				}
				else{
					pow1GOi.sprite = pows[1];
					altpowGOi.sprite = pows[3];
					ausou.clip = clips[1];
				}
				pow1GOi.color = new Color(1.0f,1.0f,1.0f,1.0f);
				altpowGOi.color = new Color(1.0f,1.0f,1.0f,1.0f);
				do{
					pow1GOt.localPosition = new Vector3(Random.Range(-412.0f,412.0f),Random.Range(-320.0f,210.0f),8.75f);
					altpowGOt.localPosition = new Vector3(Random.Range(-412.0f,412.0f),Random.Range(-320.0f,210.0f),8.75f);
				} while (pow1GOt.position == altpowGOt.position);
				StartCoroutine("Pow");
				ausou.Play();
				Powie = true;
			}
			else if (luch1.golpeado == true){
				if (luchia.tipo_golpe == 1){
					pow1GOi.sprite = pows[0];
					altpowGOi.sprite = pows[2];
					ausou.clip = clips[0];
				}
				else {
					pow1GOi.sprite = pows[1];
					altpowGOi.sprite = pows[3];
					ausou.clip = clips[1];
				}
				pow1GOi.color = new Color(1.0f,1.0f,1.0f,1.0f);
				altpowGOi.color = new Color(1.0f,1.0f,1.0f,1.0f);
				do{
					pow1GOt.localPosition = new Vector3(Random.Range(-412.0f,412.0f),Random.Range(-320.0f,210.0f),8.75f);
					altpowGOt.localPosition = new Vector3(Random.Range(-412.0f,412.0f),Random.Range(-320.0f,210.0f),8.75f);
				} while (pow1GOt.position == altpowGOt.position);
				StartCoroutine("Pow");
				ausou.Play();
				Powie = true;
			}
		}
	}
}
