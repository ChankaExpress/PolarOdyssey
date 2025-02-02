using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WipersMinigame : MonoBehaviour, IMinigameLogicController
{

    private RectTransform colliderRectTransform;
    private Canvas canvas;
    public GameObject persistentCollider;
    public Transform snowArea;
    public List<SnowScript> snowObjects;
    [SerializeField] GameObject[] prefabs;

    private MinigameInteractable minigameInteractable;

    public int numberOfClumps = 300;

    private Vector2 minCoords = new Vector2(-800, -300);
    private Vector2 maxCoords = new Vector2(800, 400);
    

    void Start()
    {
        if(prefabs==null) throw new Exception("No prefabs given!!!");

        persistentCollider.SetActive(false);
        colliderRectTransform = persistentCollider.GetComponent<RectTransform>();
        canvas = this.GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;

        snowArea = this.GetComponentsInChildren<Transform>(true)
                 .FirstOrDefault(t => t.name == "SnowArea");

        generateSnow();
    }

    void generateSnow(){
        for(int i=0; i<numberOfClumps; i++){
            GameObject go = Instantiate(
                prefabs[UnityEngine.Random.Range(0, prefabs.Length)],
                snowArea
            );
            SnowScript snow = go.GetComponent<SnowScript>();
            snow.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                UnityEngine.Random.value * (maxCoords.x - minCoords.x) + minCoords.x,
                UnityEngine.Random.value * (maxCoords.y - minCoords.y) + minCoords.y
            );
            snowObjects.Add(snow);
        }
    }

    void Update()
    {
        processMouse();
        if(Input.GetKeyDown(KeyCode.F)) minigameInteractable.EndGame();
    }

    void processMouse(){
        if (Input.GetMouseButtonDown(0))
        {
            persistentCollider.SetActive(true);
        }
        if (Input.GetMouseButton(0))
        {
            MoveColliderToMousePosition();
            pushSnow();
        }
        if (Input.GetMouseButtonUp(0))
        {
            persistentCollider.SetActive(false);
        }
    }

    void pushSnow(){
        foreach(var snow in snowObjects){
            snow.applyBroomEffect(colliderRectTransform.anchoredPosition);
        }
    }

    void MoveColliderToMousePosition()
    {
        Vector2 anchoredPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform, 
            Input.mousePosition, 
            canvas.worldCamera, 
            out anchoredPos);

        colliderRectTransform.anchoredPosition = anchoredPos;
    }

    void OnMousePress(){

    }

    public void setMinigameInteractable(MinigameInteractable val)
    {
        this.minigameInteractable = val;
    }
}
