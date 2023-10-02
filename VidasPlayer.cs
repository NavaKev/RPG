using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidasPlayer : MonoBehaviour
{
    public Image vidaPlayer;
    public Image manaPlayer; // Agrega una referencia al objeto de maná en el Inspector.
    
    private float anchoVidasPlayer;
    private float anchoManaPlayer; // Agrega una variable para el ancho del maná.
    
    public static int vida;
    public static int mana; // Agrega una variable para el maná.
    
    private bool haMuerto;
    public GameObject gameOver;
    private const int vidasINI = 5;
    private const int manaINI = 15; // Establece el valor inicial de maná.
    public static int puedePerderVida = 1;
    public static int puedePerderMana = 1; // Agrega una variable para controlar si se puede perder maná.
    
    public AudioSource audio;
    public AudioClip audio_vida;
    public AudioClip muerte;
    
    void Start()
    {
        anchoVidasPlayer = vidaPlayer.GetComponent<RectTransform>().sizeDelta.x;
        anchoManaPlayer = manaPlayer.GetComponent<RectTransform>().sizeDelta.x; // Obtiene el ancho inicial del maná.
        
        haMuerto = false;
        vida = vidasINI;
        mana = manaINI; // Inicializa el maná.
        gameOver.SetActive(false);
    }

    public void TomarDaño(int daño)
    {
        if (vida > 0 && puedePerderVida == 1)
        {
            puedePerderVida = 0;
            vida -= daño;
            DibujaVida(vida);
            audio.clip = audio_vida;
            audio.Play();
        }

        if (vida <= 0 && !haMuerto)
        {
            haMuerto = true;
            StartCoroutine(EjecutaMuerte());
        }
    }

    public void TomarMana(int dañoMana)
    {
        if (mana > 0 && puedePerderMana == 1) // Verifica si se puede perder maná.
        {
            puedePerderMana = 0;
            mana -= dañoMana;
            DibujaMana(mana);
            puedePerderMana =1;
            //Debug.Log(mana);
        }
        /*else
        {
            puedePerderMana = 1; // Restablece la capacidad de perder maná si no se puede perder en este momento.
        }*/
    }

    public void DibujaVida(int vida)
    {
        if (vida <= vidasINI)
        {
            RectTransform transformaImagen = vidaPlayer.GetComponent<RectTransform>();
            transformaImagen.sizeDelta = new Vector2(anchoVidasPlayer * (float)vida / (float)vidasINI, transformaImagen.sizeDelta.y);
        }
    }

    public void DibujaMana(int mana)
    {
        if (mana <= manaINI){
            RectTransform transformaImagen = manaPlayer.GetComponent<RectTransform>();
            transformaImagen.sizeDelta = new Vector2(anchoManaPlayer * (float)mana / (float)manaINI, transformaImagen.sizeDelta.y);
        }
    }

    IEnumerator EjecutaMuerte()
    {
        yield return new WaitForSeconds(2.1f);
        gameOver.SetActive(true);
        audio.clip = muerte;
        audio.Play();
    }
}
