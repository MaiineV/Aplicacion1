using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwap : MonoBehaviour
{
    public enum Characters
    {
        HUMAN,
        RAT,
        DOG
    }
    public Dictionary<Characters, Action> SwapFunctions = new Dictionary<Characters, Action>();
    void Start()
    {
        SwapFunctions.Add(Characters.RAT, ChangeToRat);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SwapFunctions[Characters.RAT]();
        }
    }

    public void ChangeToRat() 
    {
        Debug.Log("Rat");
    }
}
