using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAD : MonoBehaviour
{
    [SerializeField] private GameObject Proyectil;
    public float tiempoSigAtaque;
    public float tiemposEntreAtaques;
    public Transform puntoEmision;
    private Animator anim;

	public static int dirDisparo = 0; // Izquierda o Derecha 
	public static bool disparando = false;
    public AudioSource audio;
	public AudioClip ataqueDis;

    public VidasPlayer vidasPlayer;


private void Start()
    {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (tiempoSigAtaque < 0.05f && tiemposEntreAtaques > 0)
        {
            disparando = false;
        }

        if (tiempoSigAtaque > 0)
        {
            tiempoSigAtaque -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire2") && tiempoSigAtaque <= 0 && VidasPlayer.mana >= 1)
        {
            disparando = true;
            activaCapa("Ataque");
            audio.clip = ataqueDis;
            audio.Play();
            Dispara();
            tiempoSigAtaque = tiemposEntreAtaques;
            
            
        }
    }

    private void Dispara()
    {
        if (MovPlayer.dirAtaque == 1) // Derecha 
        {
            anim.SetTrigger("disparaFront");
        }
        else if (MovPlayer.dirAtaque == 2) // Izquierda
        {
            anim.SetTrigger("disparaBack");
        }
        else if (MovPlayer.dirAtaque == 3)
        {
            anim.SetTrigger("disparaLeft");
        }
        else if (MovPlayer.dirAtaque == 4)
        {
            anim.SetTrigger("disparaRight");
        }
        
        vidasPlayer.TomarMana(1);
        //Debug.Log(VidasPlayer.mana.ToString());

        

    }

    private void EmiteProyectil(){
        dirDisparo = MovPlayer.dirAtaque;
        Instantiate(Proyectil, puntoEmision.position, transform.rotation);
    }


    private void activaCapa(string nombre)
    {
        for (int i = 0; i < anim.layerCount; i++)
        {
            anim.SetLayerWeight(i, 0); // Ambos layers  con weight en 0
        }

        anim.SetLayerWeight(anim.GetLayerIndex(nombre), 1);
    }
}