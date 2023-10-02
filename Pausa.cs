using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour {

    public bool muestraPausa;

    public bool muestraVolumen;

    public GameObject goPausa;

    public GameObject goVolumen;

    // Start is called before the first frame update
    void Start() {
        muestraPausa = false;
        muestraVolumen = false;
        
    }

    public void StatusPausa() {
        if (muestraPausa) {
            muestraPausa = false;
            goPausa.SetActive(false);
            Time.timeScale = 1;

        }

        else {
            muestraPausa = true;
            goPausa.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void StatusVolumen(){
        
        if (muestraVolumen) {
            muestraVolumen = false;
            goVolumen.SetActive(false);
            Time.timeScale = 1;

        }
        else {
            muestraVolumen = true;
            goVolumen.SetActive(true);
            Time.timeScale = 0;
    }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}