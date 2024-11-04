using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SaveSystem
{
    [Serializable]
    public struct PlayerData
    {
        public float positionx;
        public float positiony;
        public float positionz;
    }

    public class SaveManager : MonoBehaviour
    {
        //Singleton
        public static SaveManager Instance;

        public void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

        }


    }

    public static class SaveManagerV2
    {
        private static string _savingPath = @"C:\\Documentos\GameSaves";

        private static Dictionary<string, ISaver> _saveItems = new Dictionary<string, ISaver>();

        public static void AddItem(string id, ISaver saver)
        {
            _saveItems.TryAdd(id, saver);
        }

        public static void SaveGameWithPlayerPref()
        {
            ////Opcion 1
            //PlayerPrefs.SetFloat("Player x", playerData.position.x);
            //PlayerPrefs.SetFloat("Player y", playerData.position.y);
            //PlayerPrefs.SetFloat("Player z", playerData.position.z);

            ////Opcion 2
            //var serializedDataUnity = JsonUtility.ToJson(playerData);
            //PlayerPrefs.SetString("PlayerPos", serializedDataUnity);
            //Debug.Log(serializedDataUnity);

            foreach (var item in _saveItems)
            {
                PlayerPrefs.SetString(item.Key, item.Value.SaveGame());
            }
        }

        public static void LoadGamePlayerPref()
        {
            //if (PlayerPrefs.HasKey("PlayerPos"))
            //{
            //    var playerPrefData = PlayerPrefs.GetString("PlayerPos");

            //    return JsonUtility.FromJson<PlayerData>(playerPrefData);
            //}
            //else
            //    return new PlayerData();


            foreach (var item in _saveItems)
            {
                if (!PlayerPrefs.HasKey(item.Key)) continue;

                var jsonData = PlayerPrefs.GetString(item.Key);

                item.Value.LoadGame(jsonData);
            }
        }

        public static void SaveGameWithFile(PlayerData playerData)
        {
            var memoryStreamer = new MemoryStream();
            var binaryFomatter = new BinaryFormatter();

            binaryFomatter.Serialize(memoryStreamer, playerData);

            if (!Directory.Exists(_savingPath))
            {
               Directory.CreateDirectory(_savingPath);
            }

            var file = File.Create( _savingPath );
            file.Write( memoryStreamer.ToArray() );
            file.Close();
        }

    }
}
