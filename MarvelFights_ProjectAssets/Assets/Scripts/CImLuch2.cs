using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CImLuch2 : MonoBehaviour {
	public Sprite[] luchers;
	Image imagen;
	Transform trans;
	Fightinfo finfo;
	void Start () {
		trans = gameObject.GetComponent<Transform>();
		imagen = gameObject.GetComponent<Image>();
		finfo = GameObject.FindObjectOfType<Fightinfo>();
		if (finfo.luchadorIA == 1 || finfo.luchadorIA == 6 || finfo.luchadorIA == 7){
			trans.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
		}
		else{
			trans.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
		}
		imagen.sprite = luchers[finfo.luchadorIA - 1];
	}
}
