using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDim : MonoBehaviour
{
    public int carLongueur, carLargeur, carHauteur;

    public void CarDimension(int longueur, int largeur, int hauteur)
    {
        carLongueur = longueur;
        carLargeur = largeur;
        carHauteur = hauteur;
    }
}
