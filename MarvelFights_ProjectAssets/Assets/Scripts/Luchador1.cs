using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Luchador1 : MonoBehaviour {
	public Sprite[] poses; SpriteRenderer pose; Transform body;
	GameObject mCamGo; Camera mCamComp; GameObject Enemigo; Vector3 extremoIzq;
	Vector3 extremoDer; bool atack = false; public bool protegido = false; int cont = 0;
	float translado = 0; bool jump = false; Vector3 Inferior; int cont2 = 0; bool jump2 = false;
	public Sprite[] salto; LuchadorIA LuchIA; public bool golpeado = false;
	int cont1 = 0; Transform transia; int cont3 = 0; bool alejarse = false; int margen = 0, margen1 = 0;
	bool actmargen = false, actmargen1 = false; public Color hurt; public Color protec; public float vida = 1.0f;
	Fightinfo finfo; public int tipo_golpe; Controlador_de_barras cbarras; bool derrotado = false; public CCanvas2 cc2;
	AudioSource ausource; public AudioClip[] auclips; 
	void Start () {
		ausource = gameObject.GetComponent<AudioSource>();
		cc2 = GameObject.FindObjectOfType<CCanvas2>();
		cbarras = GameObject.FindObjectOfType<Controlador_de_barras>();
		finfo = GameObject.FindObjectOfType<Fightinfo>();
		pose = gameObject.GetComponent<SpriteRenderer>();
		body = gameObject.GetComponent<Transform>();
		mCamGo = GameObject.Find("Main Camera");
		mCamComp = mCamGo.GetComponent<Camera>();
		extremoIzq = new Vector3(mCamComp.ScreenToWorldPoint(new Vector3(0,0,0)).x,0,0);
		extremoDer = new Vector3(mCamComp.ScreenToWorldPoint(new Vector3(Screen.width,180,0)).x,0,0);
		Inferior = new Vector3(0,mCamComp.ScreenToWorldPoint(new Vector3(0,0,0)).y,0);
		Enemigo = GameObject.FindObjectOfType<LuchadorIA>().gameObject;
		LuchIA = Enemigo.GetComponent<LuchadorIA>();
		transia = Enemigo.GetComponent<Transform>();
		hurt = new Color(0.7f,0.35f,0.35f,0.95f);
		protec = new Color(1.0f,1.0f,1.0f,0.75f);
		pose.sprite = poses[5*(finfo.luchadorJ1-1)];
	}
	void InCollision(){
		if (atack == true && golpeado == false && LuchIA.protegiendose == false){
			if (pose.sprite == poses[5*(finfo.luchadorJ1-1)+1]){
				tipo_golpe = 1;
			}
			else if (pose.sprite == poses[5*(finfo.luchadorJ1-1)+2]){
				tipo_golpe = 2;
			}
			LuchIA.cont1 = 0;
			LuchIA.golpeado = true;
			LuchIA.pose.sortingOrder = -1;
		}
		if (cont3 == 0 && LuchIA.rand5 == -1) LuchIA.rand5 = Random.Range(70,130);
		cont3++;
		if (cont3 == LuchIA.rand5){
			LuchIA.rand5 = -1;
			alejarse = true;
			StartCoroutine("Alejarse2");
			cont3 = 0;
		}
	}
	IEnumerator Derrota(){
		pose.color = hurt;
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
		if (cc2.pausa == false){
			if (cbarras.gameover == true){
				if (cbarras.J1lost == true && derrotado == false){
					StartCoroutine("Derrota");
					derrotado = true;
				}
				else{
					pose.sprite = poses[5*(finfo.luchadorJ1-1)];
				}
			}
			else{
				Comprob_Direc_Mir();
				if (LuchIA.colisiono == true){
					InCollision();
				}
				else{
					if (pose.color == protec){
						pose.color = Color.white;
					}
				}
				if (golpeado == false){
					Comprobar_Ataques(); 
					Comprobar_Movidas();
				}
				else{
					if (cont1 == 0){
						if (LuchIA.tipo_golpe == 1){
							vida = vida - 0.1f;
							ausource.clip = auclips[1];
						}
						else if (LuchIA.tipo_golpe == 2){
							vida = vida - 0.2f;
							ausource.clip = auclips[0];
						}
						pose.color = hurt;
						ausource.Play();
					}
					cont1++;
					if (cont1 == 15){
						golpeado = false;
						pose.color = Color.white;
						pose.sprite = poses[5*(finfo.luchadorJ1-1)+3];
						cont1 = 0;
						StartCoroutine("Alejarse2");
						alejarse = true;
					}
				}
			}
		}
	} 
	IEnumerator Alejarse2(){
		if (body.position.x > transia.position.x){
			for (int i = 0; i <= 15; i++){
				if (body.position.x + body.localScale.x <= extremoDer.x){
					body.Translate(0.05f,0,0);
				}
				yield return null;
			}
		}
		else if (body.position.x < transia.position.x){
			for (int i = 0; i <= 15; i++){
				if (body.position.x - body.localScale.x >= extremoIzq.x){
					body.Translate(-0.05f,0,0);
				}
				yield return null;
			}
		}
		alejarse = false;
	}
	void Comprob_Direc_Mir(){
		if (body.position.x - body.localScale.x >= transia.position.x)
			pose.flipX = true;
		if(body.position.x + body.localScale.x <= transia.position.x)
			pose.flipX = false;
	}
	void MargenDeAtaques(){
		if (atack == true){
        	cont++;
        	if (cont == 15){
        		atack = false;
        		cont = 0; actmargen1 = true;
        	}
        }
        if (actmargen1 == true){
        	margen1 = margen1 - 1;
        	if (margen1 < 0){
        		actmargen1 = false;
        		actmargen = true;
        	}
        }
        if (actmargen == true){
        	margen++;
        	if (margen == 25 + (margen1/2)) {
        		actmargen = false;
        		margen = 0;
        	}
        }
	}
	void VolverAPoseOriginal(){
		if (protegido == false && jump2 == false && actmargen1 == false && atack == false){
        	pose.sprite = poses[5*(finfo.luchadorJ1-1)];
        }
        else{
        	if (protegido == true) pose.sprite = poses[5*(finfo.luchadorJ1-1) + 4];
        	if (jump2 == true) pose.sprite = salto[finfo.luchadorJ1-1];
        }
	}
	void Comprobar_Ataques(){
		MargenDeAtaques();
		if (Input.GetButtonDown("Protec1")) {
            pose.sprite = poses[5*(finfo.luchadorJ1-1)+4];
            protegido = true;
        }
        else if(Input.GetButtonUp("Protec1")){
        	protegido = false;
        	if (atack == false && protegido == false && jump2 == false){
        		pose.sprite = poses[5*(finfo.luchadorJ1-1)];
        	}
        }
        if (Input.GetButtonDown("GRapido1")){
        	if (actmargen == false && atack == false && actmargen1 == false){
        		pose.sprite = poses[5*(finfo.luchadorJ1-1)+1];
        		atack = true;
        		ausource.clip = auclips[2];
        		ausource.Play();
        		margen1 = 0;
        	}
        }
        if (Input.GetButtonDown("GFuerte1")){
        	if (actmargen == false && atack == false && actmargen1 == false){
        		pose.sprite = poses[5*(finfo.luchadorJ1-1)+2];
        		atack = true;
        		ausource.clip = auclips[2];
        		ausource.Play();
        		margen1 = 10;
        	}
        }
        VolverAPoseOriginal();
	}
	void Comprobar_Movidas(){
		translado = Input.GetAxis("Horizontal");
		if (alejarse == false){
			if ((body.position.x - body.localScale.x >= extremoIzq.x && translado <= 0) &&
				(((body.position.x - (body.localScale.x/1.6f)) >= (transia.position.x + (transia.localScale.x/1.6f))) || 
				(pose.flipX == false) || (jump2 == true) || (LuchIA.jumping == true) || (LuchIA.dowing == true) 
				|| (LuchIA.escapando == true))){
				body.Translate(translado*0.2f,0,0);
			}
			if ((body.position.x + body.localScale.x <= extremoDer.x && translado >= 0) &&
				(((body.position.x + (body.localScale.x/1.6f)) <= (transia.position.x - (transia.localScale.x/1.6f))) ||
				(pose.flipX == true) || (jump2 == true) || (LuchIA.jumping == true) || (LuchIA.dowing == true) 
				|| (LuchIA.escapando == true))){
				body.Translate(translado*0.2f,0,0);
			}
		}
		if (Input.GetButtonDown("Salto")){
			jump = true;
			jump2 = true;
			pose.sprite = salto[finfo.luchadorJ1 - 1];
			ausource.clip = auclips[3];
        	ausource.Play();
		}
		if (Input.GetButtonUp("Salto")){
			jump = false;
		}
		if (jump == true){
			if (body.position.y <= 0.8f){
				body.Translate(0,0.35f,0);
			}
			else{
				cont2++;
				if (cont2 == 20){
					jump = false;
					cont2 = 0;
				}
			}
		}
		if (jump == false && jump2 == true){
			if (body.position.y > Inferior.y + 0.2){
				body.Translate(0,-0.3f,0);
			}
			else{
				jump2 = false;
			}
		}
	}
}