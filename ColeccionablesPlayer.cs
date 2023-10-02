using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColeccionablesPlayer : MonoBehaviour{

    private GameObject player;

    private GameObject restriccion;
    public static string objAColeccionar;
    private Inventario inventario; // 0-Sin elementos, #elemento (diferente de cero)

    public AudioSource audio;

    public AudioClip vidaAudio;

    public AudioClip manaAudio;

    private bool mochila, pergamino, herramientas, libro, sobre, mapa;

    private GameObject murallaRestriccion;

    private GameObject murallaRestriccion2;
    private GameObject murallaRestriccion3;

    private GameObject NPC_JEFE;

    private int maxVida = 5;

    private int maxMana = 15;

    void Start(){
        player = GameObject.Find("Player");
        objAColeccionar = "";
        inventario = FindObjectOfType<Inventario>();
        mochila = false;
        pergamino = false;
        herramientas = false;
        libro = false;
        sobre = false;
        mapa = false;

        murallaRestriccion = GameObject.Find("restriccion");
        murallaRestriccion2 =  GameObject.Find("restriccion_1");
        murallaRestriccion3 = GameObject.Find("restriccion_2");
        NPC_JEFE = GameObject.Find("NPC_FEJE");


    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "vida" && VidasPlayer.vida < maxVida){
            VidasPlayer.vida++;
            player.GetComponent<VidasPlayer>().DibujaVida(VidasPlayer.vida);
            Destroy(obj.gameObject);
            audio.clip = vidaAudio;
            audio.Play();

        }
        if (obj.tag == "mana" && VidasPlayer.mana < maxMana){//Aumenta mana
            VidasPlayer.mana+= 1;
            player.GetComponent<VidasPlayer>().DibujaMana(VidasPlayer.mana);
            Destroy(obj.gameObject);
            audio.clip = manaAudio;
            audio.Play();
        }

        if (obj.tag == "monedas"){
            AplicaCambios(obj);

        }

        if (obj.tag == "mochila"){
            mochila = true;
            AplicaCambios(obj);
        }

        if (obj.tag == "sobre"){
            sobre = true;
            AplicaCambios(obj);
        }

        if (obj.tag == "mapa"){
            mapa = true;
            //Debug.Log("TomoMapa");
            AplicaCambios(obj);
        }

        if (obj.tag == "libro"){
            libro = true;
            AplicaCambios(obj);
        }

        if (obj.tag == "gemaAzul"){
            AplicaCambios(obj);
        }

        if (obj.tag == "pergamino"){
            pergamino = true;

            AplicaCambios(obj);
        }

        if (obj.tag == "pocionRoja") {
            AplicaCambios(obj);
        }

        if (obj.tag == "pocionVerde"){
            AplicaCambios(obj);
        }

        if (obj.tag == "pocionAzul"){
            AplicaCambios(obj);
        }

        if (obj.tag == "gemaRoja") { 
            AplicaCambios(obj);

        }

        if (obj.tag == "gemaVerde") { 
            AplicaCambios(obj);
        }
        
        if (obj.tag== "herramientas"){
            herramientas = true;
            AplicaCambios(obj);
        }

        if (ObjetosColeccion()){
            DestruirRestriccion();
        }
    

    }

     private bool ObjetosColeccion()
    {
        // Verifica si el jugador ha recolectado todos los objetos necesarios
        return mochila && pergamino && herramientas && libro && sobre && mapa;
    }

    private void DestruirRestriccion()
    {
        // Verifica si la restricción del portal existe y si todos los objetos han sido recolectados
        if (murallaRestriccion != null && ObjetosColeccion())
        {
            // Destruye la restricción del portal
            Destroy(murallaRestriccion);
            Destroy(murallaRestriccion2);
            Destroy(murallaRestriccion3);
            Destroy(NPC_JEFE);
        }
    }
        

    private void AplicaCambios(Collider2D obj) {

        objAColeccionar = obj.tag;
        //Debug.Log(obj.tag);
        inventario.EscribeEnArreglo();
        Destroy(obj.gameObject);
    }
         
}
