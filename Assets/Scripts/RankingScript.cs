﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RankingScript : MonoBehaviour
{
  
    public Text Posicion, Nombre, Puntos;


 


    public void PonerPuntos(string pos, string nombre, string puntos)
    {
        Posicion.text = pos;
        Nombre.text = nombre;
        Puntos.text = puntos;
    }
}
