using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scriptTimer : MonoBehaviour
{
    public Text contador;
    private float tiempo = 10f;
    public ControlJugador controlJugador;

    // Start is called before the first frame update
    void Start()
    {
        contador.text = " " + tiempo;
    }

    // Update is called once per frame
    void Update()
    {
        tiempo-= Time.deltaTime;
        contador.text = " " + tiempo.ToString();
        if (tiempo <= 0)
        {
            SceneManager.LoadScene("Derrota", LoadSceneMode.Single);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
