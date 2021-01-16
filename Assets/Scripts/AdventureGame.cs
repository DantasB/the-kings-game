using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] private Text textComponent;
    [SerializeField] private State startingState;

    private State currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState       = startingState;
        textComponent.text = currentState.GetStateStory();
    }

    private void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextStates = currentState.GetNextStates();
        for(int i = 0; i < nextStates.Length; i++)
        {
            ChangeState(i, nextStates);
        }        

        textComponent.text = currentState.GetStateStory();

        EndGame();

    }

    private void ChangeState(int i, State[] nextStates)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1 + i))
        {
            currentState = nextStates[i];
        }
    }

    private void EndGame()
    {
        if (currentState.GetStateStory().ToUpper().Contains("APERTE Q"))
        {
            QuitApplication();
        }
    }

    private void QuitApplication()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }
}
