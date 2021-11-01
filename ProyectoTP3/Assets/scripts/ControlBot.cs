using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBot : MonoBehaviour
{
    private int hp;
    public ControlJugador controlJugador;
       
    void Start()      
    {
        hp = 100;
    }

    public void recibirDaño()
    {
        hp = hp - 25;

        if (hp<=0)
        {
            this.desaparecer();
        }
    }

    private void desaparecer()
    {
        Destroy(gameObject);
        controlJugador.cont += 1; 
        controlJugador.setearTextos();
        Debug.Log(controlJugador.cont);
    }
}