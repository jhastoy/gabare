using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class de la voiture avec ses dimensions
//Sert au GameObjet Empty qui va transmettre ces informations de scène en scène
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
