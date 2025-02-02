using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Test1Script : MonoBehaviour, IMinigameLogicController
{
    public List<Button> buttons;
    public List<Button> shuffledButtons;
    public GameObject rootGO;
    public MinigameInteractable minigameInteractable;
    int expectedNumber = 1;
    
    void Start()
    {
        Canvas canvas = this.gameObject.GetComponent<Canvas>();
        Camera mainCamera = Camera.main;
        if(canvas == null || mainCamera == null) {
            Debug.LogWarning("Canvas or MainCamera not found!");
            return;
        }
        canvas.worldCamera = mainCamera;

        GameObject buttonGroup = GetComponentsInChildren<Transform>(true).FirstOrDefault(t => t.name == "ButtonGroup")?.gameObject;
        if(buttonGroup == null) {
            Debug.LogWarning("ButtonGroup not found!");
            Destroy(this.gameObject);
            return;
        }

        buttons = buttonGroup.GetComponentsInChildren<Button>().ToList();
        // foreach(Button button in buttons) {
        //     GameObject go = button.gameObject;
        //     button.onClick.AddListener(() => this.PressButton(button));
        //     button.onClick.AddListener(this.DebugPrint);
        // }
        Restart();
    }

    void Restart(){
        expectedNumber = 1;

        shuffledButtons = buttons.OrderBy(a => UnityEngine.Random.Range(0, 1000)).ToList();
        int counter = 1;
        foreach(Button button in shuffledButtons){
            TextMeshProUGUI c = button.GetComponentInChildren<TextMeshProUGUI>();
            c.SetText(counter.ToString());
            counter++;
            button.interactable = true;
            button.image.color = new Color(148/255f, 245/255f, 255/255f);
        }
    }

    public void PressButton(Button button){
        Debug.Log("Button Pressed");
        int number = int.Parse(button.GetComponentInChildren<TextMeshProUGUI>().text);
        if(number != expectedNumber) {
            StartCoroutine(WrongNumber());
        } else {
            button.interactable = false;
            button.image.color = Color.green;
            expectedNumber++;
            if(expectedNumber > shuffledButtons.Count) StartCoroutine(WinGame());
        }
    }

    IEnumerator WrongNumber(){
        foreach(var button in shuffledButtons){
            button.image.color = Color.red;
            button.interactable = false;
        }
        yield return new WaitForSeconds(2f);
        Restart();
    }

    IEnumerator WinGame(){
        yield return new WaitForSeconds(2f);
        minigameInteractable.EndGame();
    }

    public void setMinigameInteractable(MinigameInteractable val)
    {
        this.minigameInteractable = val;
    }
}
