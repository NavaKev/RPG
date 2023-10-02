using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour{
    public static int vidaEnemigo = 1;

    public static int vijaJefe = 20;
    private float frecAtaque = 2.5f, tiempoSigAtaque = 0, iniciaConteo;

    public Transform personaje;
    private NavMeshAgent agente;
    public Transform[] puntosRuta;
    private int indiceRuta = 0;
    private bool playerEnRango = false;
    [SerializeField] private float distanciaDeteccionPlayer;
    private SpriteRenderer spriteEnemigo;
    private Transform mirarHacia;

    public static int puntos;
    public Text txtPuntos;

    private void Awake() {
        agente = GetComponent<NavMeshAgent>();
        //Debug.Log("Agente"+agente.ToString());
        spriteEnemigo = GetComponent<SpriteRenderer>();
    }
    

    void Start(){
        vidaEnemigo = 1;
        vijaJefe = 10;
        puntos = 1;
        agente.updateRotation = false;
        agente.updateUpAxis = false;

    }

    void Update(){
        this.transform.position = new Vector3(transform.position.x, transform.position.y, 0); // Posicion Actual del enemigo en 0
        float distancia = Vector3.Distance(personaje.position, this.transform.position); // Medir la distancia del personaje respecto al enemigo 

        if (this.transform.position == puntosRuta[indiceRuta].position) { 
            if( indiceRuta < puntosRuta.Length -1) {
                indiceRuta++;
            }else if (indiceRuta == puntosRuta.Length - 1){

                indiceRuta = 0;
            }
        }

        if (distancia < distanciaDeteccionPlayer) {
            playerEnRango = true;
        } else {
            playerEnRango = false;
        }

        if (tiempoSigAtaque > 0) {
            tiempoSigAtaque = frecAtaque + iniciaConteo - Time.time;
            //Debug.Log("Tiempo");

        }  else  {
            tiempoSigAtaque = 0;
            VidasPlayer.puedePerderVida = 1;
            SigueAlPlayer(playerEnRango);
            RotaEnemigo();
        }


    }

    private void SigueAlPlayer(bool playerEnRango) {
        if (playerEnRango){
            agente.SetDestination(personaje.position); // Sigue la posicion del personaje sobre la malla 
            mirarHacia = personaje;

        }else{
            agente.SetDestination(puntosRuta[indiceRuta].position); // El agente debe ir al destino de la animacion en donde se habia quedado 
            mirarHacia = puntosRuta[indiceRuta];
        }

    }

    private void RotaEnemigo() {
        if (this.transform.position.x > mirarHacia.position.x){
            spriteEnemigo.flipX = true;
            //Debug.Log("FlipX");

        }else {
            spriteEnemigo.flipX = false;
            //Debug.Log("Sin Flip en X");
        }
    }

    private void OnTriggerEnter2D(Collider2D obj){
        if (obj.tag == "Player"){
            tiempoSigAtaque = frecAtaque;
            iniciaConteo = Time.time;
            obj.transform.GetComponentInChildren<VidasPlayer>().TomarDaño(1);
        }
    }

    public void TomarDaño(int daño){
        vidaEnemigo -= daño;
        if (vidaEnemigo <= 0){
            EscibrePuntos(puntos++);
            Destroy(gameObject);
        }
    }

    public void TomarDañoJefe(int daño){
        vijaJefe -= daño;
        if (vijaJefe <= 0){
            EscibrePuntos(puntos++);
            Destroy(gameObject);
        }
    }

    public void EscibrePuntos(int n){
        txtPuntos.text = n.ToString();
    }
    
}
