using UnityEngine;
using System.Collections;

public class ControlPanelesPrincipales : MonoBehaviour {

	public GameObject panelCreditos;
	public GameObject panelInicial;
	public GameObject panelTutorial1;
	public GameObject panelTutorial2;
	public GameObject panelTutorial3;
	public GameObject panelSplash;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ocultarPanel(int pID){
		
		if (pID == 0) { //Ocultar Inicio
			panelInicial.SetActive(false);
		}
		if (pID == 1) { //Mostrar Creditos
			panelInicial.SetActive(false);
			panelCreditos.SetActive(true);
		}

		if (pID == 2) { //Ocultar Creditos
			panelInicial.SetActive(true);
			panelCreditos.SetActive(false);
		}

		if (pID == 3) {
			panelSplash.SetActive(false);

			/*if(panelTutorial1.SetActive(true)==true){
				panelTutorial1.SetActive(false);
				panelTutorial2.SetActive(true);
			}*/
		}
		if (pID == 4) {
			panelTutorial2.SetActive(true);
		}
		if (pID == 5) {
			panelTutorial3.SetActive(true);
		}


	}
}
