using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingHistoria : MonoBehaviour
{
    public float duracionDePantalla = 35.0f; // Duración de la pantalla en segundos

    void Start()
    {
        // Iniciar la rutina para mostrar la pantalla
        StartCoroutine(MostrarPantalla());
    }

    IEnumerator MostrarPantalla() {

        yield return new WaitForSeconds(duracionDePantalla);

        // Cambiar a la escena "Inicio"
        CambiarAEscenaInicio();
    }

    void CambiarAEscenaInicio()
    {
        // Cambiar a la escena "Inicio"
        SceneManager.LoadScene("Inicio");
    }
}
