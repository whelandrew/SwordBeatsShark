using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestCanvas : MonoBehaviour
{
    public GameboardController gbController;

    public PlayerController pController;
    public TMP_Text cursorLocationText;
    public TMP_Text playerPositionText;

    public GameObject ObjectCache;
    public TMP_Text objectTotalText;

    public TMP_Text levelNameText;

    private Level testLevel;
    private void Awake()
    {
        SetupTestLevel();
        gbController.SetCurLevel(testLevel);
            
    }
    void Update()
    {
        cursorLocationText.text = "Touch Position : " + pController.TouchPosition();
        playerPositionText.text = "Player Position : " + pController.PlayerPosition();
        objectTotalText.text = "Total Objects : " + ObjectCache.transform.childCount;
        levelNameText.text = "Running Level : " + gbController.GetCurrentLevel().lName;
    }

    private void SetupTestLevel()
    {
        testLevel = new Level();

        testLevel.lID = "testLevel24601";
        testLevel.lName = "Test Level";

        testLevel.phases = new Phases[1];
        testLevel.phases[0] = new Phases();
        testLevel.phases[0].enemies = new Entity[5];
        //create enemy objects

        testLevel.player = new Player();
        //create player

        testLevel.phases[0].boss = new Entity();

    }
}
