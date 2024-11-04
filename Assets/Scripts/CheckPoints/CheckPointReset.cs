using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointReset : MonoBehaviour
{
    void Awake()
    {
        if(PlayerPrefs.HasKey("RespawnSave"))
        {
            PlayerPrefs.DeleteKey("RespawnSave");
            PlayerPrefs.DeleteKey("RespawnSaveID");
        }
    }
}
