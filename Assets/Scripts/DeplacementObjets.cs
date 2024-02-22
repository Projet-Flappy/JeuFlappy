using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //variables
    public float vitesse;
    public float positionDebut;
    public float positionfin;
    public float deplacementAleatoire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Deplacement en Y d'une valeur aleatoire pour les colonnes
        float valeurAleatoireY = Random.Range(-deplacementAleatoire, deplacementAleatoire);

        // Si les objets arrivent a la position de fin one les deplacent vers la position de debut
        // On ajoute aussi un deplacement aleatoire en Y pour les colonnes a chaque fois quelles attainte la position finale
        if (transform.position.x < positionfin)
        {
            transform.position = new Vector3(positionDebut, valeurAleatoireY, 0);
        }

        
        // Deplacement des objets par une certaine vitesse
        transform.Translate(vitesse, 0, 0);
    }
}
