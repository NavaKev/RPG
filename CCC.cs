using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CCC : MonoBehaviour
{
    public Transform controladorGolpe;
    public float radioGolpe;
    public int dañoGolpe;
    public float tiempoEntreAtaques;
    public float tiempoSigAtaque;
	private Animator anim;
	public AudioSource audio;
	public AudioClip ataque;


    public static bool atacando;

    void Start() {
	    anim = GetComponent<Animator>();
	    audio = GetComponent<AudioSource>();

        
    }


    void Update() {
        if (tiempoSigAtaque < 0.05f && tiempoEntreAtaques > 0 ){
            atacando = false;
        }
        
        if (tiempoSigAtaque > 0 ) {
            tiempoSigAtaque -= Time.deltaTime;
        } 

	    if (Input.GetButtonDown("Fire1") && tiempoSigAtaque <= 0 ) {
            atacando = true ;
	        activaCapa("Ataque");
            Golpe();
            tiempoSigAtaque = tiempoEntreAtaques;
	    }
    }

    private void Golpe(){
        if (MovPlayer.dirAtaque == 1){
            anim.SetTrigger("ataqueFront");
        }else if (MovPlayer.dirAtaque == 2){
            anim.SetTrigger("ataqueBack");
        }else if (MovPlayer.dirAtaque == 3){
            anim.SetTrigger("ataqueLeft");
        }else if (MovPlayer.dirAtaque == 4){
            anim.SetTrigger("ataqueRight");
        }

        audio.clip = ataque;
        audio.Play();
    }


    


    private void VerificaGolpe() { // Se llama desde la animacion 
        Collider2D[] objs = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe); //verifica que golpeó
        foreach (Collider2D colisionador in objs){
            if (colisionador.CompareTag("enemigo")) { 
                colisionador.transform.GetComponent<Enemigo>().TomarDaño(dañoGolpe);
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }

    private void activaCapa(string nombre){
        for ( int i = 0; i < anim.layerCount; i++){
            anim.SetLayerWeight(i,0);
        }
        anim.SetLayerWeight(anim.GetLayerIndex(nombre), 1);

    }
    
}

