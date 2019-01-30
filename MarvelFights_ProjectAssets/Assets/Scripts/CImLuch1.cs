using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CImLuch1 : MonoBehaviour {
	public Sprite[] luchers;
	Image imagen;
	Transform trans;
	Fightinfo finfo;
	void Start () {
		trans = gameObject.GetComponent<Transform>();
		imagen = gameObject.GetComponent<Image>();
		finfo = GameObject.FindObjectOfType<Fightinfo>();
		if (finfo.luchadorJ1 == 1 || finfo.luchadorJ1 == 6 || finfo.luchadorJ1 == 7){
			trans.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
		}
		else{
			trans.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
		}
		imagen.sprite = luchers[finfo.luchadorJ1 - 1];
	}
}