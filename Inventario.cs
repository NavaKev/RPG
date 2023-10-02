using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour{

    private bool muestraInventario;
    public GameObject goInventario;
    [SerializeField] private string[] valoresInventario;
    private int numeroGemasVerdes, numeroGemasAzules, numeroGemasRojas, numeroPocionesVerdes, numeroPocionesAzules, numeroPocionesRojas;
    Button boton;
    public Sprite mochila, sobre, mapa, pergamino, libro, herramientas, gemaRoja, gemaVerde, gemaAzul, pocionRoja, pocionVerde, pocionAzul, contenedor;
    
    public AudioSource audio;

    public AudioClip inventario; 

    void Start() {
        muestraInventario = false;
        BorraArreglo();
        //Debug.Log(valoresInventario.Length.ToString());
        numeroGemasAzules = 0;
        numeroGemasRojas = 0;
        numeroGemasVerdes = 0;
        numeroPocionesRojas = 0;
        numeroPocionesAzules = 0;
        numeroPocionesVerdes = 0;
    }

    public void StatusInventario() {
        if (muestraInventario) {
            muestraInventario = false;
            goInventario.SetActive(false);
            Time.timeScale = 1;

        }
        else {
            muestraInventario = true;
            goInventario.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void EscribeEnArreglo(){
        
        if (VerificaEnArreglo() == -1) {   
         for(int i = 0; i < valoresInventario.Length; i++) { 
                if(valoresInventario[i]== "") {
                    //Debug.Log("Escribe"+i.ToString());
                    valoresInventario[i] = ColeccionablesPlayer.objAColeccionar;
                    //Debug.Log(ColeccionablesPlayer.objAColeccionar);
                    DibujaElementos(i);
                    break;
                }   
            }

        }else {
            DibujaElementos(VerificaEnArreglo());
        }

    }

    private int VerificaEnArreglo() {
        int pos = -1;
        for(int i = 0; i < valoresInventario.Length; i++) { 
            if(valoresInventario[i] == ColeccionablesPlayer.objAColeccionar) {
                pos = i;
                break;
            }
        }

        return pos;
    }

    public void DibujaElementos(int pos) {
        StatusInventario();
        boton = GameObject.Find("elemento ("+pos+")").GetComponent<Button>();
        audio.clip = inventario;
        audio.Play();
        switch (ColeccionablesPlayer.objAColeccionar) {
            case "mochila":
                contenedor = mochila;
                break;
            case "sobre":
                contenedor = sobre;
                break;
            case "mapa":
                contenedor = mapa;
                break;
            case "pergamino":
                contenedor = pergamino;
                break;
            case "libro":
                contenedor = libro;
                break;
            case "herramientas":
                contenedor = herramientas;
                break;
            case "gemaRoja":
                contenedor = gemaRoja;
                numeroGemasRojas++;
                boton.GetComponentInChildren<Text>().text = "x" + numeroGemasRojas.ToString();
                break;
            case "gemaVerde":
                contenedor = gemaVerde;
                numeroGemasVerdes++;
                boton.GetComponentInChildren<Text>().text = "x" + numeroGemasVerdes.ToString();
                break;
            case "gemaAzul":
                contenedor = gemaAzul;
                numeroGemasAzules++;
                boton.GetComponentInChildren<Text>().text = "x" + numeroGemasAzules.ToString();
                break;
            case "pocionRoja":
                contenedor = pocionRoja;
                numeroPocionesRojas++;
                boton.GetComponentInChildren<Text>().text = "x" + numeroPocionesRojas.ToString();
                break;
            case "pocionVerde":
                contenedor = pocionVerde;
                numeroPocionesVerdes++;
                boton.GetComponentInChildren<Text>().text = "x" + numeroPocionesVerdes.ToString();
                break;
            case "pocionAzul":
                contenedor = pocionAzul;
                numeroPocionesAzules++;
                boton.GetComponentInChildren<Text>().text = "x" + numeroPocionesAzules.ToString();
                break;
        }

        boton.GetComponent<Image>().sprite = contenedor;

    }

    private void BorraArreglo() {
        for (int i = 0; i < valoresInventario.Length; i++){
            valoresInventario[i] = "";
        }

    }

}
