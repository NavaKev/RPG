using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{

    private Vector2 dirMov;
    public float velMov;
    public Rigidbody2D rb;
    public Animator anim;


    private bool PlayerMoviendose = false;
    private float ultimoMovx, ultimoMovY;

    public static int dirAtaque = 0; // 1- Front, 2-Back, 3-Left, 4-Right


    void FixedUpdate() {
        Movimiento();

        if (CCC.atacando == false && CAD.disparando == false){
            AnimacionesPlayer();
        }
    }
    private void Movimiento() {
        float movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");
        dirMov = new Vector2(movX, movY).normalized; //Movimiento en X y Y
        rb.velocity = new Vector2(dirMov.x * velMov, dirMov.y * velMov); //Velocidad del player 

        if (movX == -1){
            dirAtaque = 3;
        }

        if (movX == 1 ){
            dirAtaque = 4;
        }
        
        if (movY == -1){
            dirAtaque = 1;
        }

        if (movY == 1 ){
            dirAtaque = 2;
        }

        if (movX == 0 && movY == 0) { //Idle
            PlayerMoviendose = false;
        } else { //Caminar
            PlayerMoviendose = true;
            ultimoMovx = movX;
            ultimoMovY = movY;

        }

        ActualizaCapa();
    }


    private void AnimacionesPlayer() {
        anim.SetFloat("movX", ultimoMovx); // Guarda al ultimo movimiento en X
        anim.SetFloat("movY", ultimoMovY);  // Guarda al ultimo movimiento en Y

    }

    private void ActualizaCapa() { // Cambiar entre la capa de Idle y Caminar 
        if (CCC.atacando == false && CAD.disparando == false){
            if (PlayerMoviendose) {
                activaCapa("Caminar");
            // Debug.Log("Caminando");
            } else {
                activaCapa("Idle");
                //Debug.Log("Idle");
            }
        }else{
            activaCapa("Ataque");
        }
    }

    private void activaCapa(string nombre) {
        for (int i = 0; i < anim.layerCount; i++) {
            anim.SetLayerWeight(i, 0); //Ambos layer con peso de 0
        }
        anim.SetLayerWeight(anim.GetLayerIndex(nombre), 1);
     }   
}
