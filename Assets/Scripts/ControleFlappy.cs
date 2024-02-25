using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleFlappy : MonoBehaviour
{
    // Variables publique de type float pour memoriser les vitesses en X et Y de flappy
    public float VitesseX;
    public float VitesseY;
    // Variables publique de type GameObject pour memoriser les objets qui seront desactive avec flappy
    public GameObject laPiece;
    public GameObject lePackDeVie;
    public GameObject leChampignion;
    // Variables publique de type sprite qui memorise les sprites de flappy a afficher dans le jeu
    public Sprite flappyBlesse;
    public Sprite flappyGuerit;

    // Fonction qui controle les deplacements de flappy
    void Update()
    {
        // Vitesses horizontales X
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            VitesseX = 1;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            VitesseX = -1;
        }
        else // si on n'appuit pas sur aucune des touches de deplacement en X alors flappy perd de sa vitesse graduelement 
        {
            VitesseX = GetComponent<Rigidbody2D>().velocity.x;
        }

        // Vitesses verticale Y
        if (Input.GetKeyDown(KeyCode.W)  || Input.GetKeyDown(KeyCode.UpArrow))
        {
            VitesseY = 5;
        }
        else
        {
            VitesseY = GetComponent<Rigidbody2D>().velocity.y;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(VitesseX, VitesseY);

    }

    // Fontion qui detectera les collisions que fera flappy avec les autres objets du jeu
    private void OnCollisionEnter2D(Collision2D infoCollision)
    {
            // Si une collision avec un object Colonne est detecte
        if (infoCollision.gameObject.name == "Colonne")
        {
            // On change le sprite de flappy pour l'image blesse
            GetComponent<SpriteRenderer>().sprite = flappyBlesse;
        }
            // Si une collision avec la piece est detecte
        else if (infoCollision.gameObject.name == "PieceOr")
        {
            // On desactive la piece
            infoCollision.gameObject.SetActive(false);

            // Reactivation de la piece apres quelques secondes
            Invoke("reactiverPiece", 3f);
        }
            // Si une collision avec le pack de vie est detecte
        else if (infoCollision.gameObject.name == "PackVie")
        {
            // on desactive le pack de vie 
            infoCollision.gameObject.SetActive(false);

            //reactive le pack de vie apres quelques secondes
            Invoke("reactiverPackVie", 3f);

            //On change l'image du sprite de flappy pour l'image guerit
            GetComponent<SpriteRenderer>().sprite = flappyGuerit;
        }
            // Si une collision avec le Champingon est detecte
        else if (infoCollision.gameObject.name == "Champingon")
        {
            // On desactive le champignion
            infoCollision.gameObject.SetActive(false);

            // Reactive le champignon apres quelques secondes
            Invoke("reactiverChampignion", 3f);

            // On fait Grossir Flappy de 50%
            transform.localScale *= 1.3f;
        }

    }

    // Fonctions pour reactive les objets desactives
    public void reactiverPiece()
    {
        // changement de la position en Y de la piece avant la reactivation
        // Enregistre une valeur de deplacement aleatoire en Y dans une variable locale
        float positionY = UnityEngine.Random.Range(-0.03f, 0.03f);
        // Enregistre la valeur de position X  intiales de la piece dans une variable locale
        float positionX = laPiece.transform.position.x;

        // On change la position de la piece
        laPiece.gameObject.transform.position = new Vector2(positionX, 0 + positionY);
        print(positionY);

        // on reactive la piece
        laPiece.SetActive(true);
    }
    public void reactiverPackVie()
    {
        //On reactive le pack de vie
        lePackDeVie.SetActive(true);
    }
    public void reactiverChampignion() 
    {
        // On reactive le champignion
        leChampignion.SetActive(true);

        // On rediminue la taille de flappy a sa taille initiale
        transform.localScale /= 1.3f;
    }
}
