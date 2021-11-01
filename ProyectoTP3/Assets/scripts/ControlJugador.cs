using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlJugador : MonoBehaviour
{
    public float rapidezDesplazamiento = 10.0f;
    public Camera camaraPrimeraPersona;
    public float hitDistance = 100;
    public Text textoEnemigos;
    public Text textoGanaste;
    public int cont;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cont = 0;
        textoGanaste.text = "";
        setearTextos();
    }
    public void setearTextos()
    {
        textoEnemigos.text = "Enemigos Eliminados: " + cont.ToString();
        if (cont >= 3)
        {
            SceneManager.LoadScene("Victoria", LoadSceneMode.Single);
             Cursor.lockState = CursorLockMode.Confined;
        }
    }

    void Update()
    {
        float movimientoAdelanteAtras = Input.GetAxis("Vertical") * rapidezDesplazamiento;
        float movimientoCostados = Input.GetAxis("Horizontal") * rapidezDesplazamiento;

        movimientoAdelanteAtras *= Time.deltaTime;
        movimientoCostados *= Time.deltaTime;

        transform.Translate(movimientoCostados, 0, movimientoAdelanteAtras);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

       if (Input.GetMouseButtonDown(0))
 {
       Ray ray = camaraPrimeraPersona.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
       RaycastHit hit;

       if ((Physics.Raycast(ray, out hit) == true) && hit.distance < hitDistance)
       {
            Debug.Log("El rayo tocó al objeto: " + hit.collider.name);

            if (hit.collider.name.Substring(0, 3) == "Bot")
            {
                GameObject objetoTocado = hit.collider.gameObject;
                ControlBot scriptObjetoTocado = (ControlBot)objetoTocado.GetComponentInParent((typeof(ControlBot)));

                if (scriptObjetoTocado != null)
                {
                    scriptObjetoTocado.recibirDaño();
                }
            }
       }
 }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemigo") == true)
        {
            cont = cont + 1;
            setearTextos();
            other.gameObject.SetActive(false);
        }
    } */
}