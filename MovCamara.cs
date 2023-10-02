using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    public Camera camara;

    public AudioSource audio;
	public AudioClip audioCamara;



    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "portal1") // Cambio al Escenario 2
        {
            Vector3 posicioncamara = new Vector3(23,0,-10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(17, -.5f, 0);
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }
        if (obj.gameObject.tag == "portal2") // Regresa a Escenario 1
        {
            Vector3 posicioncamara = new Vector3(0, 0, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(6.5f,-.5f, 0);
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }
        if (obj.gameObject.tag == "portal3") // Cambio a Escenario 3
        {
            Vector3 posicioncamara = new Vector3(0, 12, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(4.5f, 9, 0);
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }
        if (obj.gameObject.tag == "portal4") //Regresa al escenario 1
        {
            Vector3 posicioncamara = new Vector3(0, 0, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(4.5f,3, 0); 
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }
        if (obj.gameObject.tag == "portal5") // Cambio al escenario 4 
        {
            Vector3 posicioncamara = new Vector3(-21, 0, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(-14.5f, -1.5f, 0);
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }

        if (obj.gameObject.tag == "portal6") // Regresa al escenario 1 
        {
            Vector3 posicioncamara = new Vector3(0, 0, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(-7, -1.5f, 0);
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }
        if (obj.gameObject.tag == "portal7") // Cambia al Escenario 7
        {
            Vector3 posicioncamara = new Vector3(-1, -25, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(-5.5f, -22, 0);
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }
        if (obj.gameObject.tag == "portal8") // Regresa al escenario 1
        {
            Vector3 posicioncamara = new Vector3(0, 0, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(2.5f, -3, 0);
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }
        if (obj.gameObject.tag == "portal9") // Cambia al escenario 2
        {
            Vector3 posicioncamara = new Vector3(23, 0, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(16.37f, 2.86f, 0);
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }

        if (obj.gameObject.tag == "portal10") // Regresa al Escenario 3
        {
            Vector3 posicioncamara = new Vector3(0, 12, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(7.5f, 14.5f, 1);
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }
        if (obj.gameObject.tag == "portal11") //Cambia al escenario 5
        {
            Vector3 posicioncamara = new Vector3(-22, -12, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(-24.5f, -9, 0); ;
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }
        if (obj.gameObject.tag == "portal12") // Regresa al escenario 4
        {
            Vector3 posicioncamara = new Vector3(-21, 0, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(-25.5f, -3, 0);
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }
        if (obj.gameObject.tag == "portal13") //Cambia al escenario 6
        {
            Vector3 posicioncamara = new Vector3(-22, -25, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(-26.5f, -22, 0);   
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }

        if (obj.gameObject.tag == "portal14") //Regresa al escenario 5
        {
            Vector3 posicioncamara = new Vector3(-22, -12, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(-14.5f, -15, 0);
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }
        if (obj.gameObject.tag == "portal15") // Cambia al escenario 7
        {
            Vector3 posicioncamara = new Vector3(-1, -25, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(-8, -25.5f, 0);
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }
        if (obj.gameObject.tag == "portal16") // Regresa al escenario 6
        {
            Vector3 posicioncamara = new Vector3(-22, -25, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(-15, -26.5f, 0);
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }
        if (obj.gameObject.tag == "portal17") // Cambia al Escenenario 9
        {
            Vector3 posicioncamara = new Vector3(23, -12, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(15.5f, -14, 0);
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }
        if (obj.gameObject.tag == "portal18") // Regresa al escenario 7
        {
            Vector3 posicioncamara = new Vector3(-1, -25, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(5.5f,-28.5f, 0);
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }
        if (obj.gameObject.tag == "portal19") //Cambia al Escenario 8
        {
            Vector3 posicioncamara = new Vector3(23, -12, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(20.5f, -9, 0);
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
            
        }

        if (obj.gameObject.tag == "portal20") // Regresa al Escenario 2
        {
            Vector3 posicioncamara = new Vector3(23, 0, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(20.5f,-2.5f, 0);
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }

        if (obj.gameObject.tag == "portal21") // Cambia al escenario 9
        {
            Vector3 posicioncamara = new Vector3(45, -12, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(50, -10, 0);
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }
        if (obj.gameObject.tag == "portal22") // Regresa al escenario 8
        {
            Vector3 posicioncamara = new Vector3(23, -12, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(30, -14.5f, 0);
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }

        if (obj.gameObject.tag == "portal23") // Escenario con el Jefe
        {
            Vector3 posicioncamara = new Vector3(45, -25, -10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(40.25f, -25f, 0);
            this.transform.position = posicionPlayer;
            audio.clip = audioCamara;
            audio.Play();
        }
    }

}
