using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CEscenario : MonoBehaviour {
	public Sprite[] escenarios;
	Fightinfo finfo;
	Image sprend;
	void Start () {
		sprend = gameObject.GetComponent<Image>();
		finfo = GameObject.FindObjectOfType<Fightinfo>();
		sprend.sprite = escenarios[finfo.escenario];
	}
}
