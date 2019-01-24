using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimacionFondo : MonoBehaviour {
	Image fondo; bool courin = false; public Sprite[] fondos;
	float transp = 1.0f; int count = 0;
	void Start () {
		fondo = gameObject.GetComponent<Image>();
	}
	void Update () {
		if (courin == false){
			StartCoroutine("EfectoFondo");
			courin = true;
		}
	}
	IEnumerator EfectoFondo(){
		for (int i = 0; i < 20; i++){
			transp = transp - 0.05f;
			fondo.color = new Color(transp,transp,transp,1.0f);
			yield return null;
		}
		count++;
		fondo.sprite = fondos[count];
		if (count == 5){
			count = -1;
		}
		for (int i = 0; i < 20; i++){
			transp = transp + 0.05f;
			fondo.color = new Color(transp,transp,transp,1.0f);
			yield return null;
		}
		yield return new WaitForSeconds(2.0f);
		courin = false;
	}
}
