using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetOnCar : MonoBehaviour
{
    //Liste des équipements présents sur la voiture
    public List<ItemOnCar> ItemsOnCars = new List<ItemOnCar>();
    public string where; //variable qui indique si l'objet se trouve sur le toit ou au niveau du coffre

   
    //Ajout de l'équipement selectionné à la liste des équipements présents sur le véhicule
    public void ItemPotentielInfo(string name, int longueur, int largeur, int hauteur, double localx, double localy, double localz, float rotation)
    {
        ItemOnCar NewItem = new ItemOnCar(name, longueur, largeur, hauteur, localx, localy, localz, rotation, where);
        ItemsOnCars.Add(NewItem);
    }

    
    public void CoffreOuToit(string name)
    {
        if(name== "Add_Button_Track")
        {
            where = "Track";
        }
        if(name== "Add_Button_Roof")
        {
            where = "Roof";
        }
    }
    
}


//Class des objets sur 
[SerializeField]
public class ItemOnCar
{
    public string Name;
    public int Longueur;
    public int Largeur;
    public int Hauteur;
    public double Localx;
    public double Localy;
    public double Localz;
    public float Rotation;
    public string Place;

    public ItemOnCar(string name, int longueur, int largeur, int hauteur, double localx, double localy, double localz, float rotation, string where)
    {
        Name = name;
        Longueur = longueur;
        Largeur = largeur;
        Hauteur = hauteur;
        Localx = localx;
        Localy = localy;
        Localz = localz;
        Rotation = rotation;
        Place = where;
    }


}
