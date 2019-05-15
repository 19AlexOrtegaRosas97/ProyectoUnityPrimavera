using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class levelManager : MonoBehaviour
{
    public float Tiempo = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Tiempo += Time.deltaTime;

        if (Tiempo >= 30.0f || Input.GetButton("Fire1"))
        {
            CargarNivel("SampleScene");
        }
        if (Input.GetButton("Fire2"))
        {
            CargarNivel("Contexto");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarNivel(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);

    }   
}
