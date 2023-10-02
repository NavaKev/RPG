using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public GameObject txtDialogo;
    public int numVisitas;

    public Sprite txt1, txt2;

    void Start(){
        txtDialogo.SetActive(false);
        numVisitas = 0;
    }

    private void OnTriggerEnter2D(Collider2D obj) {
        if (obj.tag == "Player"){
            txtDialogo.SetActive(true);
            EscribeDialogo();
        }
    }

    private void EscribeDialogo() {
        switch (numVisitas) { 
            case 0:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = txt1;
                break;
            case 1:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = txt2;
                break;
            case 2:
                txtDialogo.SetActive(false); // Oculta el cuadro de diálogo después de mostrar ambos diálogos.
                numVisitas = -1; // Reinicia el contador de visitas.
                break;
        }
        numVisitas++;
    }
}

