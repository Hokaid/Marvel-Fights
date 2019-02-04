using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuchadorIA : MonoBehaviour {
	public Sprite[] poses; public Sprite[] salto; GameObject mCamGo; Camera mCamComp; Vector3 extremoIzq, extremoDer,
	Inferior; public bool golpeado = false; Transform body; GameObject J1; Transform transj1; public int cont1 = 0;
	int cont = 0; int cont2 = 0; int cont3 = 0; int pSqui = 0;
	public SpriteRenderer pose; Luchador1 luch1; SpriteRenderer j1pose;
	bool atack = false; bool atacking = false; public bool protegiendose = false;
	public bool jumping = false; public bool dowing = false; bool alejarse = false; bool alej1 = false;
	int cont4 = 0; int escape = 0; public bool escapando = false; int rand1, rand3;
	int rand4; public int rand5; public float vida = 1.0f; public int tipo_golpe; int cont5 = 0;
	public bool colisiono = false; public int dificultad = 1; float rand6, rand2;
	Fightinfo finfo; Controlador_de_barras cbarras; bool derrotado = false; public CCanvas2 cc2;
	AudioSource ausource; public AudioClip[] auclips;
	void Start () {
		ausource = gameObject.GetComponent<AudioSource>();
		cc2 = GameObject.FindObjectOfType<CCanvas2>();
		cbarras = GameObject.FindObjectOfType<Controlador_de_barras>();
		finfo = GameObject.FindObjectOfType<Fightinfo>();
		pose = gameObject.GetComponent<SpriteRenderer>();
		J1 = GameObject.FindObjectOfType<Luchador1>().gameObject;
		body = gameObject.GetComponent<Transform>();
		transj1 = J1.GetComponent<Transform>();
		luch1 = J1.GetComponent<Luchador1>();
		j1pose = J1.GetComponent<SpriteRenderer>();
		dificultad = finfo.dificultad;
		pose.sprite = poses[5*(finfo.luchadorIA-1)];
		mCamGo = GameObject.Find("Main Camera");
		mCamComp = mCamGo.GetComponent<Camera>();
		extremoIzq = new Vector3(mCamComp.ScreenToWorldPoint(new Vector3(0,0,0)).x,0,0);
		extremoDer = new Vector3(mCamComp.ScreenToWorldPoint(new Vector3(Screen.width,180,0)).x,0,0);
		Inferior = new Vector3(0,mCamComp.ScreenToWorldPoint(new Vector3(0,0,0)).y,0);
		if (finfo.luchadorIA == finfo.luchadorJ1){
			pose.color = new Color(1.0f,0.3f,1.0f,1.0f);
		}
	}
	IEnumerator Atacar(){
		if (dificultad == 1){
			yield return new WaitForSeconds(Random.Range(0.3f,0.6f));
		}
		else if (dificultad == 2){
			yield return new WaitForSeconds(Random.Range(0.2f,0.4f));
		}
		else if (dificultad == 3){
			yield return new WaitForSeconds(Random.Range(0.1f,0.2f));
		}
		pose.sprite = poses[5*(finfo.luchadorIA-1)+1];
		atack = true;
		ausource.clip = auclips[2];
        ausource.Play();
		yield return new WaitForSeconds(0.3f);
		pose.sprite = poses[5*(finfo.luchadorIA-1)+2];
		atack = true;
		ausource.clip = auclips[2];
        ausource.Play();
		yield return new WaitForSeconds(0.45f);
		atacking = false;
	}
	void OnTriggerEnter2D(){
		if (protegiendose == false && alejarse == false && escapando == false){
			if (golpeado == false && atacking == false) {
				StartCoroutine("Atacar");
				atacking = true;
			}
		}
		colisiono = true;
	}
	void OnTriggerExit2D(){
		if (protegiendose == false && golpeado == false && alejarse == false){
			StopCoroutine("Atacar");
			atacking = false;
			if (jumping == true || dowing == true || escapando == true){
				pose.sprite = salto[finfo.luchadorIA - 1];
			}
			else {
				pose.sprite = poses[5*(finfo.luchadorIA-1)];
			}
		}
		colisiono = false;
	}
	void Saltando(){ 
		if (jumping == false && dowing == false){
			if (cont3 == 0){
				if (dificultad == 1){
					rand1 = Random.Range(350,600);
				}
				else if (dificultad == 2){
					rand1 = Random.Range(300,400);
				}
				else if (dificultad == 3){
					rand1 = Random.Range(200,300);
				}
			}
			cont3++;
			if (cont3 == rand1){
				jumping = true;
				pose.sprite = salto[finfo.luchadorIA - 1];
				cont3 = 0;
				ausource.clip = auclips[3];
        	    ausource.Play();
			}
		}
		else if (jumping == true) {
			if (cont3 == 0){
				if (dificultad == 1){
					rand2 = Random.Range(0.35f,0.7f);
				}
				else if (dificultad == 2){
					rand2 = Random.Range(0.5f,0.75f);	
				}
				else if (dificultad == 3){
					rand2 = Random.Range(0.65f,0.85f);
				}
				cont3 = 1;
			}
			if (body.position.y <= rand2){
				body.Translate(0,0.15f,0);
			}
			else{
				jumping = false;
				dowing = true;
				cont3 = 0;
			}
		}
		else if (dowing == true){
			if (body.position.y > Inferior.y + 0.15) {
				body.Translate(0,-0.15f,0);
			}
			else{
				dowing = false;
				pose.sprite = poses[5*(finfo.luchadorIA-1)];
				cont3 = 0;
			}
		}
	}
	void Moverse(){
		if (atacking == false && escapando == false){
			Saltando();
		}
		if ((body.position.x - (body.localScale.x/1.6f)) > (transj1.position.x + (transj1.localScale.x/1.6f))){
			if (dificultad == 1){
				rand6 = Random.Range(0.01f,0.075f);
			}
			else if (dificultad == 2){
				rand6 = Random.Range(0.05f,0.1f);	
			}
			else if (dificultad == 3){
				rand6 = Random.Range(0.08f,0.1f);
			}
			body.Translate(-1*rand6,0,0);
			pose.flipX = true;
		}
		else if ((body.position.x + (body.localScale.x/1.6f)) < (transj1.position.x - (transj1.localScale.x/1.6f))){
			if (dificultad == 1){
				rand6 = Random.Range(0.01f,0.075f);
			}
			else if (dificultad == 2){
				rand6 = Random.Range(0.05f,0.1f);	
			}
			else if (dificultad == 3){
				rand6 = Random.Range(0.08f,0.1f);
			}
			body.Translate(rand6,0,0);
			pose.flipX = false;
		}
	}
	IEnumerator Escapar(){
		if (dificultad == 1){
			rand2 = Random.Range(0.35f,0.7f);
		}
		else if (dificultad == 2){
			rand2 = Random.Range(0.5f,0.75f);	
		}
		else if (dificultad == 3){
			rand2 = Random.Range(0.65f,0.85f);
		}
		ausource.clip = auclips[3];
        ausource.Play();
        bool finishi = false, subi = true;
		if (body.position.x > transj1.position.x){
			do{
				if (body.position.x - body.localScale.x >= extremoIzq.x){
					body.Translate(-0.05f,0,0);
				}
				if (subi == true){
					if (body.position.y <= rand2){
						body.Translate(0,0.15f,0);
					}
					else{
						subi = false;
					}
				}
				else {
					if (body.position.y > Inferior.y + 0.15) {
						body.Translate(0,-0.15f,0);
					}
					else {
						finishi = true;
					}
				}
				yield return null;
			}while(finishi == false);
		}
		else if (body.position.x < transj1.position.x){
			do{
				if (body.position.x + body.localScale.x <= extremoDer.x){
					body.Translate(0.05f,0,0);
				}
				if (subi == true){
					if (body.position.y <= rand2){
						body.Translate(0,0.15f,0);
					}
					else{
						subi = false;
					}
				}
				else {
					if (body.position.y > Inferior.y + 0.15) {
						body.Translate(0,-0.15f,0);
					}
					else {
						finishi = true;
					}
				}
				yield return null;
			}while(finishi == false);
		}
		escapando = false;
	}
	void Golpeado(){
		if (escape == 0){
			if (dificultad == 1){
				rand3 = Random.Range(2,7);
			}
			else if (dificultad == 2){
				rand3 = Random.Range(1,4);
			}
			else if (dificultad == 3){
				rand3 = Random.Range(1,2);
			}
		}
		if (escape == rand3 && escapando == false){
			escape = 0;
			StartCoroutine("Escapar");
			pose.sprite = salto[finfo.luchadorIA - 1];
			escapando = true;
		}
		if (pSqui == 0){
			if (dificultad == 1){
				rand4 = Random.Range(1,4);
			}
			else if (dificultad == 2){
				rand4 = Random.Range(1,3);
			}
			else if (dificultad == 3){
				rand4 = Random.Range(1,2);
			}
		}
		if (pSqui == rand4){
			pose.sprite = poses[5*(finfo.luchadorIA-1)+4];
			pSqui = 0;
			protegiendose = true;
			golpeado = false;
		}
		else{
			pose.sprite = poses[5*(finfo.luchadorIA-1)+3];
		}
		if(cont1 == 0){
			StopCoroutine("Atacar");
			atacking = false;
		}
		if (protegiendose == false){
			pose.color = luch1.hurt;
		}
		else{
			pose.color = luch1.protec;
			luch1.tipo_golpe = 3;
		}
		if (cont1 == 1 && protegiendose == false){
			if (luch1.tipo_golpe == 1){
				vida = vida - 0.1f;
				ausource.clip = auclips[0];
			}
			else if (luch1.tipo_golpe == 2){
				vida = vida - 0.2f;
				ausource.clip = auclips[1];
			}
			ausource.Play();
		}
		cont1++;
		if (cont1 == 15){
			pSqui++;
			escape++;
			golpeado = false;
			pose.color = Color.white;
			if (finfo.luchadorIA == finfo.luchadorJ1){
				pose.color = new Color(1.0f,0.3f,1.0f,1.0f);
			}
			alejarse = true;
			if (jumping == true || dowing == true || escapando == true){
				pose.sprite = salto[finfo.luchadorIA - 1];
			}
			else{
				pose.sprite = poses[5*(finfo.luchadorIA-1)];
			}
			cont1 = 0;
		}
	}
	void Protegiendose(){
		if (cont2 == 0){
			luch1.tipo_golpe = 3;
			StopCoroutine("Atacar");
			atacking = false;
		}
		cont2++;
		if (cont2 == 20){
			protegiendose = false;
			if (jumping == true || dowing == true|| escapando == true){
				pose.sprite = salto[finfo.luchadorIA - 1];
				pose.color = Color.white;
				if (finfo.luchadorIA == finfo.luchadorJ1){
					pose.color = new Color(1.0f,0.3f,1.0f,1.0f);
				}
			}
			else{
				pose.sprite = poses[5*(finfo.luchadorIA-1)];
				pose.color = Color.white;
				if (finfo.luchadorIA == finfo.luchadorJ1){
					pose.color = new Color(1.0f,0.3f,1.0f,1.0f);
				}
			}
			cont2 = 0;
		}
	}
	void Atacando(){
		if (atack == true){
			cont++;
			if (cont == 15){
				atack = false;
				cont = 0;
			}
		}
	}
	IEnumerator Alejarse(){
		if (body.position.x > transj1.position.x){
			for (int i = 0; i <= 15; i++){
				if (body.position.x + body.localScale.x <= extremoDer.x){
					body.Translate(0.05f,0,0);
				}
				yield return null;
			}
		}
		else if (body.position.x < transj1.position.x){
			for (int i = 0; i <= 15; i++){
				if (body.position.x - body.localScale.x >= extremoIzq.x){
					body.Translate(-0.05f,0,0);
				}
				yield return null;
			}
		}
		alejarse = false;
		alej1 = false;
	}
	void Flip(){
		if ((body.position.x - (body.localScale.x/1.6f)) > (transj1.position.x + (transj1.localScale.x/1.6f))){
			pose.flipX = true;
		}
		else if ((body.position.x + (body.localScale.x/1.6f)) < (transj1.position.x - (transj1.localScale.x/1.6f))){
			pose.flipX = false;
		}
	}
	void InCollision(){
		if (protegiendose == false){
			if (atacking == true){
				if (golpeado == false){
					if (atack == true){
						pose.sortingOrder = 1;
						if (luch1.protegido == false){
							if (pose.sprite == poses[5*(finfo.luchadorIA-1)+1]){
								tipo_golpe = 1;
							}
							else if (pose.sprite == poses[5*(finfo.luchadorIA-1)+2]){
								tipo_golpe = 2;
							}
							luch1.golpeado = true;
							j1pose.sprite = luch1.poses[5*(finfo.luchadorJ1-1)+3];
						}
						else{
							if (cont5 == 0){
								tipo_golpe = 0;
							}
							cont5++;
							if (cont5 == 15){
								tipo_golpe = 3;
								cont5 = 0;
							}
							j1pose.color = luch1.protec;
						}
					}
					else{
						if (j1pose.color == luch1.protec){
							j1pose.color = Color.white;
							if (finfo.luchadorIA == finfo.luchadorJ1){
								pose.color = new Color(1.0f,0.3f,1.0f,1.0f);
							}
						}
					}
				}
				else {
					StopCoroutine("Atacar");
					atacking = false;
					if (jumping == true || dowing == true|| escapando == true){
						pose.sprite = salto[finfo.luchadorIA - 1];
					}
					else {
						pose.sprite = poses[5*(finfo.luchadorIA-1)+3];
					}
				}
			}
			else{
				if (golpeado == false) {
					StartCoroutine("Atacar");
					atacking = true;
				}
			}
		}
		if (cont4 == 0 && rand5 == -1) rand5 = Random.Range(70,130);
		cont4++;
		if (cont4 == rand5){
			rand5 = -1;
			alejarse = true;
			StartCoroutine("Alejarse");
			cont4 = 0;
		}
	}
	IEnumerator Derrota(){
		pose.color = luch1.hurt;
		yield return new WaitForSeconds(0.2f);
		pose.color = new Color(1.0f,1.0f,1.0f,0.7f);
		yield return new WaitForSeconds(0.2f);
		pose.color = new Color(1.0f,0.0f,0.0f,0.6f);
		yield return new WaitForSeconds(0.2f);
		pose.color = new Color(1.0f,1.0f,1.0f,0.5f);
		yield return new WaitForSeconds(0.15f);
		pose.color = new Color(1.0f,0.0f,0.0f,0.4f);
		yield return new WaitForSeconds(0.15f);
		pose.color = new Color(1.0f,1.0f,1.0f,0.3f);
		yield return new WaitForSeconds(0.15f);
		pose.color = new Color(1.0f,0.0f,0.0f,0.2f);
		yield return new WaitForSeconds(0.1f);
		pose.color = new Color(1.0f,1.0f,1.0f,0.1f);
		yield return new WaitForSeconds(0.1f);
		pose.color = new Color(1.0f,1.0f,1.0f,0.0f);
	}
	void Update () {
		if (cc2.pausa == false && cc2.instart == false){
			if (cbarras.gameover == true){
				if (cbarras.J1lost == false && derrotado == false){
					StartCoroutine("Derrota");
					derrotado = true;
				}
				else{
					pose.sprite = poses[5*(finfo.luchadorIA-1)];
				}
			}
			else{
				Flip();
				if (colisiono){
					InCollision();
				}
				if (alejarse == true && escapando == false){
					if (alej1 == false){
						StopCoroutine("Atacar");
						atacking = false;
						StartCoroutine("Alejarse");
						alej1 = true;
					}
				}
				if (golpeado == true && protegiendose == false){
					Golpeado();
				}
				else if (protegiendose == true){
					Protegiendose();
				}
				else{
					Moverse();
					Atacando();
				}
			}
		}
	}
}
