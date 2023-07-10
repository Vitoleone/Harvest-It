using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [Header("Attributes")] 
    [SerializeField] private Transform world;
    
    [Header("Data")] 
    private WorldData worldData;
    private string dataPath;

    private void Awake()
    {
        Chunk.onUnlock += ChunkUnlockedCallback;
    }

    
    void Start()
    {
        dataPath = Application.dataPath + "/WorldData.txt";
        LoadWorld();
        Initialize();
    }

    private void OnDestroy()
    {
        Chunk.onUnlock -= ChunkUnlockedCallback;
    }

    void Update()
    {
        
    }
    
    private void Initialize()
    {
        for (int i = 0; i < world.childCount; i++)
        {
            world.GetChild(i).GetComponent<Chunk>().Initialize(worldData.chunkPrices[i]);
        }
    }
    
    private void ChunkUnlockedCallback()
    {
        
        SaveWorld();
    }

    void LoadWorld()
    {
        string data = "";
        if (!File.Exists(dataPath))
        {
            FileStream fs = new FileStream(dataPath, FileMode.Create);
            worldData = new WorldData(world.childCount);
            for (int i = 0; i < world.childCount; i++)
            {
                worldData.chunkPrices[i] = world.GetChild(i).GetComponent<Chunk>().GetInitialPrice();
            }
            string worldDataString = JsonUtility.ToJson(worldData, true);
            byte[] worldDataBytes = Encoding.UTF8.GetBytes(worldDataString);
            fs.Write(worldDataBytes);
            fs.Close();
        }
        else
        {
            data = File.ReadAllText(dataPath);
            worldData = JsonUtility.FromJson<WorldData>(data);
        }
       
        
    }

    void SaveWorld()
    {
        if (worldData.chunkPrices.Length != world.childCount)
        {
            worldData = new WorldData(world.childCount);
        }

        for (int i = 0; i < world.childCount; i++)
        {
            worldData.chunkPrices[i] = world.GetChild(i).GetComponent<Chunk>().GetCurrentPrice();
        }

        string data = JsonUtility.ToJson(worldData, true);
        File.WriteAllText(dataPath,data);
    }
}
