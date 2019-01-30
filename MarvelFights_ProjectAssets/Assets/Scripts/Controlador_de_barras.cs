using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlador_de_barras : MonoBehaviour {
	GameObject j1b, iab, aj1b, aiab, IA, J1, h1, h2, h3, h4, MenuGOver, oscuro, cartel, gameOv;
	Image ih3, ih4, ij1b, iiab, ih1, ih2, ioscu;
	Text tcartel;
	Scrollbar sj1b, siab, saj1b, saiab;
	LuchadorIA ia; Luchador1 j1; 
	Color nada, red, blanco, amarillo, cell;
	float auxvidaj1, auxvidaia; int cont1 = 0, cont2 = 0; bool inred1 = false, inred2 = false, incell1 = false, incell2 = false,
	goverstar = false; RectTransform rth1, rth2; public bool gameover = false; public CCanvas2 cc2; 
	public bool J1lost = false;
	void Start () {
		gameOv = GameObject.Find("GameOver");
		cc2 = GameObject.FindObjectOfType<CCanvas2>();
		cartel = GameObject.Find("Cartel");
		tcartel = cartel.GetComponent<Text>();
		oscuro = GameObject.Find("Oscurecido");
		ioscu = oscuro.GetComponent<Image>();
		MenuGOver = GameObject.Find("MenuGOver");
		j1b = GameObject.Find("J1Bar");
		iab = GameObject.Find("IABar");
		aj1b = GameObject.Find("auxbarj1");
		aiab = GameObject.Find("auxbaria");
		ij1b = j1b.GetComponent<Image>();
		iiab = iab.GetComponent<Image>();
		sj1b = j1b.GetComponent<Scrollbar>();
		siab = iab.GetComponent<Scrollbar>();
		saj1b = aj1b.GetComponent<Scrollbar>();
		saiab = aiab.GetComponent<Scrollbar>();
		IA = GameObject.FindObjectOfType<LuchadorIA>().gameObject;
		J1 = GameObject.FindObjectOfType<Luchador1>().gameObject;
		ia = IA.GetComponent<LuchadorIA>();
		j1 = J1.GetComponent<Luchador1>();
		h1 = GameObject.Find("Handle1");
		h2 = GameObject.Find("Handle2");
		h3 = GameObject.Find("Handle3");
		h4 = GameObject.Find("Handle4");
		ih3 = h3.GetComponent<Image>();
		ih4 = h4.GetComponent<Image>();
		ih1 = h1.GetComponent<Image>();
		ih2 = h2.GetComponent<Image>();
		rth1 = h1.GetComponent<RectTransform>();
		rth2 = h2.GetComponent<RectTransform>();
		auxvidaj1 = j1.vida;
		auxvidaia = ia.vida;
		sj1b.size = j1.vida;
		siab.size = ia.vida;
		nada = new Color(0.9f,0.2f,0.2f,0.0f);
		red = new Color(0.9f,0.2f,0.2f,1.0f);
		blanco = new Color(1.0f,1.0f,1.0f,0.6f);
		amarillo = new Color(0.9f,0.9f,0.1f,1.0f);
		cell = new Color(0.3f,0.7f,0.6f);
		ij1b.color = amarillo;
		iiab.color = amarillo;
		ih3.color = nada;
		ih4.color = nada;
		MenuGOver.SetActive(false);
		gameOv.SetActive(false);
	}
	IEnumerator GameOverStart(){
		float color = 1.0f, transparencia = 0.0f;
		for (int i = 0; i < 10; i++){
			color = color - 0.1f;
			transparencia = transparencia + 0.04f;
			ioscu.color = new Color(color, color, color, transparencia);
			yield return new WaitForSeconds(0.125f);
		}
		ioscu.color = new Color(0.0f,0.0f,0.0f,0.412f);
		MenuGOver.SetActive(true);
		if (J1lost == false){
			tcartel.text = "ganaste!!!";
		}
		else{
			tcartel.text = "perdiste!!!";
		}
	}
	void Update () {
		if (cc2.pausa == false){
			if (gameover == true && goverstar == false) {
				StartCoroutine("GameOverStart");
				gameOv.SetActive(true);
				goverstar = true;
			}
			else if (goverstar == false) {
				if (auxvidaj1 <= 0.0f){
					if (j1.vida < 0.0f || ia.tipo_golpe == 3){
						inred1 = true;
						ih3.color = red;
						saj1b.value = 0.0f;
						saj1b.size = 0.0f;
						if (ij1b.color == amarillo){
							auxvidaj1 = 1.0f;
							j1.vida = 1.0f;
							sj1b.size = 1.0f;
							ih1.color = amarillo;
							ij1b.color = blanco;
						}
						else{
							rth1.localScale = rth1.localScale - new Vector3(1.0f,0.0f,0.0f);
							gameover = true;
							J1lost = true;
						}
					}
				}
				else{
					if (auxvidaj1 > j1.vida || ia.tipo_golpe == 3){
						inred1 = true;
						ih3.color = red;
						saj1b.value = j1.vida;
						if (ia.tipo_golpe == 3){
							saj1b.size = 0.0f;
							j1.vida = j1.vida - 0.015f;
							incell1 = true; ih3.color = cell;
							ia.tipo_golpe = 0;
						}
						else if (auxvidaj1 - j1.vida == 0.1f){
							saj1b.size = 0.0f;
						}
						else if (auxvidaj1 - j1.vida == 0.2f){
							saj1b.size = 0.1f;
						}
						sj1b.size = j1.vida;
						auxvidaj1 = j1.vida;
						if (j1.vida <= 0){
							j1.vida = 0;
							auxvidaj1 = 0;
						}
					}
				}
				if (auxvidaia <= 0.0f){
					if (ia.vida < 0.0f || j1.tipo_golpe == 3){
						inred2 = true;
						ih4.color = red;
						saiab.value = 0.0f;
						saiab.size = 0.0f;
						if (iiab.color == amarillo){
							auxvidaia = 1.0f;
							ia.vida = 1.0f;
							siab.size = 1.0f;
							ih2.color = amarillo;
							iiab.color = blanco;
						}
						else{
							rth2.localScale = rth2.localScale - new Vector3(1.0f,0.0f,0.0f);
							gameover = true;
						}
					}
				}
				else{
					if (auxvidaia > ia.vida || j1.tipo_golpe == 3){
						inred2 = true;
						ih4.color = red;
						saiab.value = ia.vida;
						if (j1.tipo_golpe == 3){
							saiab.size = 0.0f;
							ia.vida = ia.vida - 0.015f;
							incell2 = true; ih4.color = cell;
							j1.tipo_golpe = 0;
						}
						else if (auxvidaia - ia.vida == 0.1f){
							saiab.size = 0.0f;
						}
						else if (auxvidaia - ia.vida == 0.2f){
							saiab.size = 0.1f;
						}
						siab.size = ia.vida;
						auxvidaia = ia.vida;
						if (ia.vida <= 0){
							ia.vida = 0;
							auxvidaia = 0;
						}
					}
				}
				if (inred1 == true && incell1 == false){
					cont1++;
					if (cont1%2 == 0){
						ih3.color = red;
					}
					else{
						ih3.color = nada;
					}
					if (cont1 == 6){
						cont1 = 0;
						inred1 = false;
						ih3.color = nada;
					}
				}
				if (incell1 == true){
					cont1++;
					if (cont1%2 == 0){
						ih3.color = cell;
					}
					else{
						ih3.color = nada;
					}
					if (cont1 == 6){
						cont1 = 0;
						incell1 = false;
						inred1 = false;
						ih3.color = nada;
					}
				}
				if (inred2 == true && incell2 == false){
					cont2++;
					if (cont2%2 == 0){
						ih4.color = red;
					}
					else{
						ih4.color = nada;
					}
					if (cont2 == 6){
						cont2 = 0;
						inred2 = false;
						ih4.color = nada;
					}
				}
				if (incell2 == true){
					cont2++;
					if (cont2%2 == 0){
						ih4.color = cell;
					}
					else{
						ih4.color = nada;
					}
					if (cont2 == 6){
						cont2 = 0;
						incell2 = false;
						inred2 = false;
						ih4.color = nada;
					}
				}
			}
		}
	}
}
