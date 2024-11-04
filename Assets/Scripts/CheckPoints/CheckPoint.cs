using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public int checkPointNumber;

    [SerializeField] private Transform _respawnPosition;
    [SerializeField] private Transform _lookingPoint;

    void Awake()
    {
        CheckPointManager.Instace.AddCheckPoint(gameObject.name, this);
    }

    public void LoadCheckPoint(Transform player)
    {
        player.position = _respawnPosition.position;
        player.LookAt(_lookingPoint);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 7) return;

        if (PlayerPrefs.HasKey("RespawnSaveID") && PlayerPrefs.GetInt("RespawnSaveID") > checkPointNumber) return;

        PlayerPrefs.SetString("RespawnSave", gameObject.name);
        PlayerPrefs.SetInt("RespawnSaveID", checkPointNumber);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
