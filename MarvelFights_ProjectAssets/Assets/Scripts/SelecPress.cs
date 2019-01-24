using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class SelecPress : MonoBehaviour {
	GameObject Antman, Abominacion, Thor, Ultron, Bucky, Deadpool, Ironman, Venom, J1Fighter, IAFigther, sescetext, nescene, 
	der, izq, fondoGO, botonRefrescar, botonGo, Fbutt, Nbutt, Dbutt; Fightinfo FightInf;
	Image iJ1f, iIAf, iAntman, iAbominacion, iThor, iUltron, iBucky, iDeadpool, iIronman, iVenom, fondo, ibder, ibizq, ibrgo;
	public Sprite[] luchers, escenarios; GameObject J1FName, IAFName, SelecName;
	Text J1FNtext, IAFNtext, SelecNtext, NomEtext, sescText; bool J1selec = false, IAselec = false, inover = false, inhabili = false,
	selecDifi = false; Transform J1Ft, IAFt, tbrgo; Animator canvasani; int pesc = 0;
	public AudioSource ausource; Button brebutt;
	void Start () {
		ausource = gameObject.GetComponent<AudioSource>();
		Fbutt = GameObject.Find("FacilButton");
		Nbutt = GameObject.Find("NormalButton");
		Dbutt = GameObject.Find("DificilButton");
		botonRefrescar = GameObject.Find("BotonRefrescar");
		brebutt = botonRefrescar.GetComponent<Button>();
		botonGo  = GameObject.Find("BotonGo");
		fondoGO = GameObject.Find("Fondo_Selec");
		FightInf = GameObject.FindObjectOfType<Fightinfo>();
		fondo = fondoGO.GetComponent<Image>();
		sescetext = GameObject.Find("SelecEscetext");
		sescText = sescetext.GetComponent<Text>();
		nescene = GameObject.Find("NomEscene");
		NomEtext = nescene.GetComponent<Text>();
		der = GameObject.Find("Derecha");
		izq = GameObject.Find("Izquierda");
		ibder = der.GetComponent<Image>();
		ibizq = izq.GetComponent<Image>();
		Antman = GameObject.Find("Antman");
		Abominacion = GameObject.Find("Abominacion");
		Thor = GameObject.Find("Thor");
		Ultron = GameObject.Find("Ultron");
		Bucky = GameObject.Find("Bucky");
		Deadpool = GameObject.Find("Deadpool");
		Ironman = GameObject.Find("Ironman");
		Venom = GameObject.Find("Venom");
		J1Fighter = GameObject.Find("J1Fighter");
		IAFigther = GameObject.Find("IAFigther");
		J1Ft = J1Fighter.GetComponent<Transform>();
		IAFt = IAFigther.GetComponent<Transform>();
		iJ1f = J1Fighter.GetComponent<Image>();
		iIAf = IAFigther.GetComponent<Image>();
		iAntman = Antman.GetComponent<Image>();
		iAbominacion = Abominacion.GetComponent<Image>();
		iThor = Thor.GetComponent<Image>();
		iUltron = Ultron.GetComponent<Image>();
		iBucky = Bucky.GetComponent<Image>();
		iDeadpool = Deadpool.GetComponent<Image>();
		iIronman = Ironman.GetComponent<Image>();
		iVenom = Venom.GetComponent<Image>();
		J1FName = GameObject.Find("J1FigtherName");
		IAFName = GameObject.Find("IAFigtherName");
		SelecName = GameObject.Find("SelecText");
		J1FNtext = J1FName.GetComponent<Text>();
		IAFNtext = IAFName.GetComponent<Text>();
		SelecNtext = SelecName.GetComponent<Text>();
		canvasani = gameObject.GetComponent<Animator>();
		sescetext.SetActive(false);
		nescene.SetActive(false);
		der.SetActive(false);
		izq.SetActive(false);
		botonGo.SetActive(false);
		Fbutt.SetActive(false);
		Nbutt.SetActive(false);
		Dbutt.SetActive(false);
	}
	void Update () {}
	public void Refrescar(){
		J1selec = false;
		IAselec = false;
		iJ1f.sprite = luchers[1];
		iJ1f.color = Color.black;
		J1Ft.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
		J1FNtext.color = new Color(0.1f,1.0f,0.0f,1.0f);
		iIAf.sprite = luchers[1];
		iIAf.color = Color.black;
		IAFt.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
		IAFNtext.color = new Color(0.9f,0.0f,0.0f,1.0f);
		SelecNtext.text = "Selecciona tu luchador";
		SelecNtext.color = new Color(0.0f,0.1f,0.8f,1.0f);
		J1FNtext.text = "------------";
		IAFNtext.text = "------------";
	}
	public void GO(){
		if (selecDifi == false){
			selecDifi = true;
			canvasani.SetBool("Puerta", false);
			ausource.Play();
			sescText.text = "Selecciona la dificultad";
			sescText.color = new Color(0.15f,1.0f,0.0f,1.0f);
			nescene.SetActive(false);
			der.SetActive(false);
			izq.SetActive(false);
			Fbutt.SetActive(true);
			Nbutt.SetActive(true);
			Dbutt.SetActive(true);
		}
		else{
			FightInf.dificultad = 1;
			SceneManager.LoadScene("Fight");
		}
	}
	public void EasyButton(){
		FightInf.dificultad = 1;
		SceneManager.LoadScene("Fight");
	}
	public void NormalButton(){
		FightInf.dificultad = 2;
		SceneManager.LoadScene("Fight");
	}
	public void HardButton(){
		FightInf.dificultad = 3;
		SceneManager.LoadScene("Fight");
	}
	public void Volver(){
		SceneManager.LoadScene("Menu");
	}
	public void EscenarioDer(){
		if (inhabili == false){
			pesc++;
			switch (pesc) {
				case 6: NomEtext.text = "Templo de Tokyo"; NomEtext.color = new Color(0.2f,0.3f,1.0f,1.0f); break;
				case 1: NomEtext.text = "Gimnasio"; NomEtext.color = new Color(1.0f,0.5f,0.9f,1.0f); break;
				case 2: NomEtext.text = "Galaxia 407"; NomEtext.color = new Color(0.2f,1.0f,0.2f,1.0f); break;
				case 3: NomEtext.text = "Templo de Taychi"; NomEtext.color = new Color(1.0f,0.9f,0.0f,1.0f); break;
				case 4: NomEtext.text = "Fuerza Aerea"; NomEtext.color = new Color(1.0f,0.0f,0.2f,1.0f); break;
				case 5: NomEtext.text = "Aeropuerto"; NomEtext.color = new Color(0.9f,0.4f,0.0f,1.0f); break;
				default: NomEtext.text = "----------"; NomEtext.color = new Color(0.2f,0.3f,1.0f,1.0f); break;
			}
			if (pesc >= 6){
				pesc = 0;
			}
			canvasani.SetBool("Puerta", false);
			ausource.Play();
			StartCoroutine("ChangeEscenario");
		}
	}
	public void EscenarioIzq(){
		if (inhabili == false){
			pesc = pesc - 1;
			switch (pesc) {
				case 0: NomEtext.text = "Templo de Tokyo"; NomEtext.color = new Color(0.2f,0.3f,1.0f,1.0f); break;
				case 1: NomEtext.text = "Gimnasio"; NomEtext.color = new Color(1.0f,0.5f,0.9f,1.0f); break;
				case 2: NomEtext.text = "Galaxia 407"; NomEtext.color = new Color(0.2f,1.0f,0.2f,1.0f); break;
				case 3: NomEtext.text = "Templo de Taychi"; NomEtext.color = new Color(1.0f,0.9f,0.0f,1.0f); break;
				case 4: NomEtext.text = "Fuerza Aerea"; NomEtext.color = new Color(1.0f,0.0f,0.2f,1.0f); break;
				case -1: NomEtext.text = "Aeropuerto"; NomEtext.color = new Color(0.9f,0.4f,0.0f,1.0f); break;
				default: NomEtext.text = "----------"; NomEtext.color = new Color(0.2f,0.3f,1.0f,1.0f); break;
			}
			if (pesc <= -1){
				pesc = 5;
			}
			canvasani.SetBool("Puerta", false);
			ausource.Play();
			StartCoroutine("ChangeEscenario");
		}
	}
	public void Click(){
		if (J1selec == false){
			J1selec = true;
			SelecNtext.text = "Selecciona tu oponente";
			SelecNtext.color = new Color(0.7f,0.2f,0.0f,1.0f);
		}
		else if (IAselec == false && inover == true){
			IAselec = true;
			StartCoroutine("pequeCoroutine");
		}
		inover = false;
	}
	IEnumerator pequeCoroutine(){
		yield return new WaitForSeconds(0.82f);
		brebutt.interactable = false;
		canvasani.SetBool("Change", true);
		yield return new WaitForSeconds(1.5f);
		ausource.Play();
		yield return new WaitForSeconds(1.6f);
		fondo.sprite = escenarios[pesc];
		sescetext.SetActive(true);
		nescene.SetActive(true);
		der.SetActive(true);
		izq.SetActive(true);
		botonRefrescar.SetActive(false);
		botonGo.SetActive(true);
		canvasani.SetBool("Puerta", true);
		ausource.Play();
	}
	IEnumerator ChangeEscenario(){
		yield return new WaitForSeconds(1.13f);
		inhabili = true;
		ibder.color = new Color(0.2f,0.2f,0.2f,0.7f);
		ibizq.color = new Color(0.2f,0.2f,0.2f,0.7f);
		fondo.sprite = escenarios[pesc];
		FightInf.escenario = pesc;
		canvasani.SetBool("Puerta", true);
		yield return new WaitForSeconds(1.0f);
		ausource.Play();
		yield return new WaitForSeconds(1.5f);
		inhabili = false;
		ibder.color = new Color(1.0f,1.0f,1.0f,1.0f);
		ibizq.color = new Color(1.0f,1.0f,1.0f,1.0f);
	}
	void SelecFchange(int pos, string name){
		inover = true;
		if (J1selec == false){
			iJ1f.sprite = luchers[pos];
			iJ1f.color = Color.white;
			J1FNtext.text = name;
			switch (name) {
				case "Antman": J1FNtext.color = new Color(1.0f,0.37f,0.0f,1.0f); FightInf.luchadorJ1 = 1; break;
				case "Abominación": J1FNtext.color = new Color(0.4f,0.9f,0.0f,1.0f); FightInf.luchadorJ1 = 2; break;
				case "Thor": J1FNtext.color = new Color(0.92f,0.9f,0.0f,1.0f); FightInf.luchadorJ1 = 3; break;
				case "Ultron": J1FNtext.color = new Color(0.7f,0.0f,0.3f,1.0f); FightInf.luchadorJ1 = 4; break;
				case "Bucky": J1FNtext.color = new Color(0.05f,0.2f,0.4f,1.0f); FightInf.luchadorJ1 = 5; break;
				case "Deadpool": J1FNtext.color = new Color(0.5f,0.1f,0.1f,1.0f); FightInf.luchadorJ1 = 6; break;
				case "Ironman": J1FNtext.color = new Color(0.05f,0.8f,0.65f,1.0f); FightInf.luchadorJ1 = 7; break;
				case "Venom": IAFNtext.color = new Color(0.15f,0.3f,0.2f,1.0f); FightInf.luchadorJ1 = 8; break;
				default: J1FNtext.color = new Color(0.1f,1.0f,0.0f,1.0f); FightInf.luchadorJ1 = 0; break;
			}
			if (name == "Thor" || name == "Ultron" || name == "Bucky" || name == "Venom"){
				J1Ft.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
			}
			else{
				J1Ft.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
			}
		}
		else if (IAselec == false) {
			iIAf.sprite = luchers[pos];
			iIAf.color = Color.white;
			IAFNtext.text = name;
			switch (name)
			{
				case "Antman": IAFNtext.color = new Color(1.0f,0.37f,0.0f,1.0f); FightInf.luchadorIA = 1; break;
				case "Abominación": IAFNtext.color = new Color(0.4f,0.9f,0.0f,1.0f); FightInf.luchadorIA = 2; break;
				case "Thor": IAFNtext.color = new Color(0.92f,0.9f,0.0f,1.0f); FightInf.luchadorIA = 3; break;
				case "Ultron": IAFNtext.color = new Color(0.7f,0.0f,0.3f,1.0f); FightInf.luchadorIA = 4; break;
				case "Bucky": IAFNtext.color = new Color(0.05f,0.2f,0.4f,1.0f); FightInf.luchadorIA = 5; break;
				case "Deadpool": IAFNtext.color = new Color(0.5f,0.1f,0.1f,1.0f); FightInf.luchadorIA = 6; break;
				case "Ironman": IAFNtext.color = new Color(0.05f,0.8f,0.65f,1.0f); FightInf.luchadorIA = 7; break;
				case "Venom": IAFNtext.color = new Color(0.15f,0.3f,0.2f,1.0f); FightInf.luchadorIA = 8; break;
				default: IAFNtext.color = new Color(0.1f,1.0f,0.0f,1.0f); FightInf.luchadorIA = 0; break;
			}
			if (name == "Thor" || name == "Ultron" || name == "Bucky" || name == "Venom"){
				IAFt.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
			}
			else{
				IAFt.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
			}
		}
	}
	public void AntmanOver() {
		iAntman.color = new Color(0.6f,0.6f,0.6f,1.0f);
		SelecFchange(0, "Antman");
	}
	public void AbominacionOver() {
		iAbominacion.color = new Color(0.6f,0.6f,0.6f,1.0f);
		SelecFchange(1, "Abominación");
	}
	public void ThorOver() {
		iThor.color = new Color(0.6f,0.6f,0.6f,1.0f);
		SelecFchange(2, "Thor");
	}
	public void UltronOver() {
		iUltron.color = new Color(0.6f,0.6f,0.6f,1.0f);
		SelecFchange(3, "Ultron");
	}
	public void BuckyOver() {
		iBucky.color = new Color(0.6f,0.6f,0.6f,1.0f);
		SelecFchange(4, "Bucky");
	}
	public void DeadpoolOver() {
		iDeadpool.color = new Color(0.6f,0.6f,0.6f,1.0f);
		SelecFchange(5, "Deadpool");
	}
	public void IronmanOver() {
		iIronman.color = new Color(0.6f,0.6f,0.6f,1.0f);
		SelecFchange(6, "Ironman");
	}
	public void VenomOver() {
		iVenom.color = new Color(0.6f,0.6f,0.6f,1.0f);
		SelecFchange(7, "Venom");
	}
	public void InExit() {
		inover = false;
		if (J1selec == false){
			iJ1f.sprite = luchers[1];
			iJ1f.color = Color.black;
			J1Ft.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
			J1FNtext.color = new Color(0.1f,1.0f,0.0f,1.0f);
		}
		else if (IAselec == false){
			iIAf.sprite = luchers[1];
			iIAf.color = Color.black;
			IAFt.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
			IAFNtext.color = new Color(0.9f,0.0f,0.0f,1.0f);
		}
	}
	void TextDefault(){
		if (J1selec == false){
			J1FNtext.text = "------------";
		}
		else if (IAselec == false){
			IAFNtext.text = "------------";
		}
	}
	public void AntmanExit() {
		iAntman.color = new Color(1.0f,1.0f,1.0f,1.0f);
		TextDefault();
	}
	public void AbominacionExit() {
		iAbominacion.color = new Color(1.0f,1.0f,1.0f,1.0f);
		TextDefault();
	}
	public void ThorExit() {
		iThor.color = new Color(1.0f,1.0f,1.0f,1.0f);
		TextDefault();
	}
	public void UltronExit() {
		iUltron.color = new Color(1.0f,1.0f,1.0f,1.0f);
		TextDefault();
	}
	public void BuckyExit() {
		iBucky.color = new Color(1.0f,1.0f,1.0f,1.0f);
		TextDefault();
	}
	public void DeadpoolExit() {
		iDeadpool.color = new Color(1.0f,1.0f,1.0f,1.0f);
		TextDefault();
	}
	public void IronmanExit() {
		iIronman.color = new Color(1.0f,1.0f,1.0f,1.0f);
		TextDefault();
	}
	public void VenomExit() {
		iVenom.color = new Color(1.0f,1.0f,1.0f,1.0f);
		TextDefault();
	}
}
