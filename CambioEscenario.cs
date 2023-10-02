using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenario : MonoBehaviour {
    public void MainaHistoria(){
		SceneManager.LoadScene("Historia");
	}

	public void MainaInicio(){
		SceneManager.LoadScene("inicio");
	}

	public void InicioaMenu(){
		SceneManager.LoadScene("Menu");
		Time.timeScale = 1;
	}
	
	public void MainaCreditos(){
		SceneManager.LoadScene("Creditos");
	}


}
