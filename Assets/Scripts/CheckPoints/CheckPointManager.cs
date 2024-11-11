using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public static CheckPointManager Instace;

    private Dictionary<string, CheckPoint> CheckPointsDictionary = new();

    private List<CheckPoint> CheckPointList = new();

    [SerializeField] private Transform _player;

    void Awake()
    {
        Instace = this;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("RespawnSave"))
        {
            var saveKey = PlayerPrefs.GetString("RespawnSave");

            //Opcion diccionario
            if (CheckPointsDictionary.ContainsKey(saveKey))
                CheckPointsDictionary[saveKey].LoadCheckPoint(_player);

            //Opcion Lista
            foreach (var item in CheckPointList)
            {
                if(item.name.Equals(saveKey))
                    item.LoadCheckPoint(_player);
            }
        }
    }

    [ContextMenu("Test Checkpoints")]
    public void TestCheckPoint()
    {
        Debug.Log("Test");
        if (PlayerPrefs.HasKey("RespawnSave"))
        {
            var saveKey = PlayerPrefs.GetString("RespawnSave");

            //Opcion diccionario
            if (CheckPointsDictionary.ContainsKey(saveKey))
                CheckPointsDictionary[saveKey].LoadCheckPoint(_player);

            //Opcion Lista
            foreach (var item in CheckPointList)
            {
                if (item.name.Equals(saveKey))
                    item.LoadCheckPoint(_player);
            }
        }
    }

    public void AddCheckPoint(string checkPointName, CheckPoint checkPoint)
    {
        CheckPointsDictionary.TryAdd(checkPointName, checkPoint);

        if (!CheckPointList.Contains(checkPoint))
            CheckPointList.Add(checkPoint);
    }
}
