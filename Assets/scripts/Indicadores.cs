using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Indicadores : MonoBehaviour {


	public bool estado;
	public Animator animator;
	public Text valores;
	public Text valores2;
	public Text valores3;
	public Text valores4;

	public GameObject vertice;
	public GameObject intersepto1;
	public Text intersepto1Texto;
	public GameObject intersepto2;
	public Text intersepto2Texto;
	public GameObject[] sliders;
	public Image botonFuncion;
	public Image botonMenu;
	public Image botonVertice;
	public Image botonIntercepto;
	public Image botonValores;
	public Image botonExponencialImg;

	public GameObject fondoExponencial;
	public GameObject fondointerceptos;
	public GameObject fondoExponencial2;


	public Sprite spriteMenuOn;
	public Sprite spriteMenuOff;
	public Sprite verticeOn;
	public Sprite verticeOff;
	public Sprite interceptoOn;
	public Sprite interceptoOff;
	public Sprite slidersOn;
	public Sprite slidersOff;
	public Sprite funcionOn;
	public Sprite funcionOff;
	public Sprite exponencialOn;
	public Sprite exponencialOff;

	float a = 1;
	float b = 0;
	float c = 0;
	string cuadratica ;
	string interceptos;
	string vertices;
	string funcion;

	public bool banderaVertice = false;
	public bool banderaExponencial = false;
	public bool banderainterceptos = false;
	public bool banderaSliders = true;
	public bool banderaExponenteSlider = true;
	public Text tm ;


	float h = 0;
	float k = 0;
	// Use this for initialization
	void Start () {
		crearGrafica();
		//animator.SetBool("cerrar", true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void cerrar(){
		if(estado){
			animator.SetBool("cerrar", false);
			estado = false;
			botonMenu.sprite = spriteMenuOff;
		}else{
			animator.SetBool("cerrar", true);
			estado = true;
			botonMenu.sprite = spriteMenuOn;
		}
	}
	public void activaSliders(){
		if(banderaSliders){
			sliders[0].SetActive(false);
			sliders[1].SetActive(false);
			banderaSliders = false;
			botonValores.sprite = slidersOn;
		}else{
			if(banderaExponenteSlider){
				sliders[0].SetActive(true);
			}else{
				sliders[1].SetActive(true);
			}
			banderaSliders = true;
			botonValores.sprite = slidersOff;
		}
	}
	public void exponenteSlider(){

		if (banderaExponenteSlider) {
			if (banderaSliders) {
				sliders [0].SetActive (false);
				sliders [1].SetActive (true);
			}
			if(banderaExponencial){
				fondoExponencial.gameObject.SetActive(false);
				fondoExponencial2.gameObject.SetActive(true);
			}
			banderaExponenteSlider = false;
			botonExponencialImg.sprite = exponencialOff;
		} else {
			if (banderaSliders) {
				sliders [0].SetActive (true);
				sliders [1].SetActive (false);
			}
			if(banderaExponencial){
				fondoExponencial.gameObject.SetActive(true);
				fondoExponencial2.gameObject.SetActive(false);
			}
			banderaExponenteSlider = true;
			botonExponencialImg.sprite = exponencialOn;
		}

	}

	public void activaFuncion( ){
		if(!banderaExponencial){

			if(banderainterceptos){
				activaIntersepto();
			}
			if(banderaVertice){
				activaVertice();
			}
			if(banderaExponenteSlider){
				fondoExponencial.gameObject.SetActive(true);
				banderaExponencial = true;
				banderainterceptos = false;
				banderaVertice = false;
				valores.text = "";
				string funcion2="";
				valores2.text = "";
				funcion = "f(x) =  <color=#FFE600>"+a.ToString ("n2")+" </color>e";
				funcion2= funcion2 + "<color=#00A7FF>"+b.ToString ("n2")+"</color>x"; 							
				valores.text = valores.text + funcion;
				valores2.text = valores2.text +funcion2;
			}else{
				fondoExponencial2.gameObject.SetActive(true);
				banderaExponencial = true;
				banderainterceptos = false;
				banderaVertice = false;
				valores3.text = "";
				string funcion2 = "";
				valores4.text = "";
				funcion = "f(x) =  <color=#FFE600>" + a.ToString ("n2") + " </color>(<color=#00A7FF>" + b.ToString ("n2") + "</color>)";
				funcion2 = funcion2 + "<color=#298A08>" + c.ToString ("n2") + "</color>x"; 
				valores3.text = valores3.text + funcion;
				valores4.text = valores4.text + funcion2;
			}

			botonFuncion.sprite = funcionOff;

		}else{
			banderaExponencial = false;
			banderainterceptos = false;
			banderaVertice = false;
			botonFuncion.sprite = funcionOn;
			fondoExponencial.gameObject.SetActive(false);
			fondoExponencial2.gameObject.SetActive(false);
		}
	}
	public void activaIntersepto( ){
		if(!banderainterceptos){
			if(banderaExponencial){
				activaFuncion();
			}
			if(banderaVertice){
				activaVertice();
			}

			fondointerceptos.gameObject.SetActive(true);
			banderainterceptos = true;
			intersepto1.GetComponent<Animator>().enabled=true;
			intersepto2.GetComponent<Animator>().enabled=true;
			intersepto1Texto.gameObject.SetActive(true);
			intersepto2Texto.gameObject.SetActive(true);
			botonIntercepto.sprite = interceptoOff;
		}else{
			fondointerceptos.gameObject.SetActive(false);
			banderainterceptos = false;
			intersepto1.GetComponent<Animator>().enabled=false;
			intersepto2.GetComponent<Animator>().enabled=false;
			intersepto1.GetComponent<MeshRenderer>().enabled=true;
			intersepto2.GetComponent<MeshRenderer>().enabled=true;
			intersepto1Texto.gameObject.SetActive(false);
			intersepto2Texto.gameObject.SetActive(false);
			botonIntercepto.sprite = interceptoOn;
		
		}
	}
	public void activaVertice( ){
		if(!banderaVertice){
			if(banderaExponencial){
				activaFuncion();
			}
			if(banderainterceptos){
				activaIntersepto();
			}

			fondoExponencial2.gameObject.SetActive(true);
			banderaVertice = true;
			vertice.GetComponent<Animator>().enabled=true;
			//tm = vertice.GetComponentInChildren<TextMesh>();
			tm.transform.gameObject.SetActive(true);
			tm.text= "("+h.ToString ("n2")+","+k.ToString ("n2")+")";
			botonVertice.sprite = verticeOff;
		}else{
			vertice.GetComponent<Animator>().enabled=false;
			vertice.GetComponent<MeshRenderer>().enabled=true;
			fondoExponencial2.gameObject.SetActive(false);
			tm.transform.gameObject.SetActive(false);
			banderaVertice = false;
			botonVertice.sprite = verticeOn;

		}
	}
	public void cambiarA(float nA)
	{
		a=nA;
		crearGrafica();
	}
	
	public void cambiarB(float nB)
	{
		b=nB;
		crearGrafica();
	}
	
	public void cambiarC(float nC)
	{
		c=nC;
		crearGrafica();
	}
	public void crearGrafica(){
		//if (banderaExponencial){
		if (banderaExponenteSlider) {
			valores.text = "";
			string funcion2 = "";
			valores2.text = "";
			funcion = "f(x) =  <color=#FFE600>" + a.ToString ("n2") + " </color>e";
			funcion2 = funcion2 + "<color=#00A7FF>" + b.ToString ("n2") + "</color>x"; 
			valores.text = valores.text + funcion;
			valores2.text = valores2.text + funcion2;
		} else {
			valores3.text = "";
			string funcion2 = "";
			valores4.text = "";
			funcion = "f(x) =  <color=#FFE600>" + a.ToString ("n2") + " </color>(<color=#00A7FF>" + b.ToString ("n2") + "</color>)";
			funcion2 = funcion2 + "<color=#298A08>" + c.ToString ("n2") + "</color>x"; 
			valores3.text = valores3.text + funcion;
			valores4.text = valores4.text + funcion2;
		}
	//	}


	}
}
