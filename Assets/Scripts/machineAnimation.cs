using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class machineAnimation : MonoBehaviour
{
    [Header("Simulation de l'etat recçu: Niveau et Etat des neurones")]
    [SerializeField]
    int Niveau;
    [SerializeField]
    int codeEtat;
    [SerializeField]
    public bool anim_running;

    [Header("Variables de paramétrages d'animation")]
    [SerializeField]
    float distanceMiniArret;
    [SerializeField]
    float rotationToMove;
    [SerializeField]
    float speedYurE;
    [SerializeField]
    Vector3 targetScaleObjet;

    [Header("Prefab des objets de Yur-E")]
    [SerializeField]
    GameObject objetTenuSpawner;
    [SerializeField]
    GameObject prefabParapluieOuvert;
    [SerializeField]
    GameObject prefabParapluieFerme;

    [Header("Sprite de Yur_E")]
    [SerializeField]
    GameObject bodyObject;
    [SerializeField]
    Sprite spriteMoveLeft;
    [SerializeField]
    Sprite spriteMoveRight;
    [SerializeField]
    Sprite spriteDefault;
    [SerializeField]
    Sprite spriteDefaultFache;
    [SerializeField]
    Sprite spriteFacheMoveLeft;
    [SerializeField]
    Sprite spriteFacheMoveRight;
    [SerializeField]
    Sprite spriteContent;
    [SerializeField]
    Sprite spriteContentMoveLeft;
    [SerializeField]
    Sprite spriteContentMoveRight;
    [SerializeField]
    Sprite spriteBlase;
    [SerializeField]
    Sprite spriteBlaseMoveLeft;
    [SerializeField]
    Sprite spriteBlaseMoveRight;
    [SerializeField]
    Sprite spriteInquiet;
    [SerializeField]
    Sprite spriteInquietMoveLeft;
    [SerializeField]
    Sprite spriteInquietMoveRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame





    public void frapperParticule()
    {
        //this.sortirObjet(this.prefabParapluie);
        this.prepareToMove(GameObject.FindWithTag("incident"));
        if (goToDestination(GameObject.FindWithTag("incident"), "fache"))
        {
            GameObject parapluie = this.sortirObjet(this.prefabParapluieFerme);
            parapluie.GetComponent<outil_behaviour>().frapper();
        }
    }

    public void prepareToMove(GameObject target)
    {
        if (target.transform.position.x > this.transform.position.x)
        {
            bodyObject.GetComponent<SpriteRenderer>().sprite = this.spriteMoveRight;
        }
        else
        {
            bodyObject.GetComponent<SpriteRenderer>().sprite = this.spriteMoveLeft;
        }
    }

    public bool goToDestination(GameObject destination, string emotion)
    {
        float distance = Vector2.Distance(this.transform.position, destination.transform.position);
        if(distance > this.distanceMiniArret)
        {
            this.transform.position = Vector2.Lerp(this.transform.position, destination.transform.position, Time.deltaTime * this.speedYurE);
            return false;
        }
        else
        {
            this.anim_running = false;
            this.idle(emotion);
            return true;
        }
    }

    public GameObject sortirObjet(GameObject prefabObjet)
    {
        GameObject objetTenu = null;
        if (this.objetTenuSpawner.GetComponentsInChildren<Transform>().Length <= 1)
        {
           objetTenu = Instantiate(prefabObjet, this.objetTenuSpawner.transform);
           objetTenu.tag = "objetTenu";
        }
        return objetTenu;
    }

    public void utilisationObjet(GameObject prefabObjet, GameObject target, string action)
    {
        switch (action)
        {
            case "frapper":
                prefabObjet.transform.position = Vector2.Lerp(prefabObjet.transform.position, target.transform.position, Time.deltaTime * this.speedYurE);
                return;
            case "protection":
                return;
            default:
                break;
        }
    }

    public void idle(string emotion)
    {
        Sprite sprite = null;
        switch (emotion)
        {
            case "fache":
                sprite = this.spriteDefaultFache;
                break;
            default:
                break;
        }
        bodyObject.GetComponent<SpriteRenderer>().sprite = sprite;
        //Balancer l'anim du Idle ici
    }
}
