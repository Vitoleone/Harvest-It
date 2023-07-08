using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropField : MonoBehaviour
{
   [Header("Attributes")] 
   [SerializeField] private Transform tilesParent;
   private List<CropTile> croptiles = new List<CropTile>();
   [Header("Settings")]
   public CropData cropData;
   private TileFieldState state;
   private int tilesSeeded;
   private int tilesWatered;
   [Header("Actions")] 
   public static Action<CropField> onFullySeeded;
   public static Action<CropField> onFullyWatered;

   private void Start()
   {
      state = TileFieldState.Empty;
      StoreTiles();
   }

   private void StoreTiles()
   {
      for (int i = 0; i < tilesParent.childCount; i++)
      {
         croptiles.Add(tilesParent.GetChild(i).GetComponent<CropTile>());
      }
   }

   [NaughtyAttributes.Button()]
   void InstantSeedTiles()
   {
      for (int i = 0; i < croptiles.Count; i++)
      {
         Seed(croptiles[i]);
      }
   }
   [NaughtyAttributes.Button()]
   void InstantWaterTiles()
   {
      for (int i = 0; i < croptiles.Count; i++)
      {
         Water(croptiles[i]);
      }
   }

   public void SeedsCollidedCallback(Vector3[] seedPositions)
   {
      for (int i = 0; i < seedPositions.Length; i++)
      {
         CropTile closestCropTile = GetClosestCropTile(seedPositions[i]);
         if(closestCropTile == null)
            continue;
         if(!closestCropTile.IsEmpty())
            continue;
         Seed(closestCropTile);
      }
   }

   private void Seed(CropTile closestCropTile)
   {
      closestCropTile.Seed(cropData);
      tilesSeeded++;
      if (tilesSeeded == croptiles.Count)
         FieldFullySeeded();
   }

   private void FieldFullySeeded()
   {
      state = TileFieldState.Seeded;
      onFullySeeded?.Invoke(this);
   }

   private CropTile GetClosestCropTile(Vector3 seedPosition)
   {
      float minDistance = 5000;
      int closestCropTileIndex = -1;
      for (int i = 0; i < croptiles.Count; i++)
      {
         CropTile cropTile = croptiles[i];
         float distanceTileToSeed = Vector3.Distance(cropTile.transform.position, seedPosition);

         if (distanceTileToSeed < minDistance)
         {
            minDistance = distanceTileToSeed;
            closestCropTileIndex = i;
         }
      }

      if (closestCropTileIndex == -1)
         return null;

      return croptiles[closestCropTileIndex];
   }
   public bool IsEmpty()
   {
      return state == TileFieldState.Empty;
   }

   public void WaterCollidedCallback(Vector3[] waterPositions)
   {
      for (int i = 0; i < waterPositions.Length; i++)
      {
         CropTile closestCropTile = GetClosestCropTile(waterPositions[i]);
         if(closestCropTile == null)
            continue;
         if(!closestCropTile.IsSeeded())
            continue;
         Water(closestCropTile);
         tilesWatered++;
         if (tilesWatered == croptiles.Count)
         {
            FieldFullyWatered();
         }
      }
   }

   private void FieldFullyWatered()
   {
      state = TileFieldState.Watered;
      onFullyWatered?.Invoke(this);
   }

   private void Water(CropTile closestCropTile)
   {
      closestCropTile.Water();
   }

   public bool IsSeeded()
   {
      return state == TileFieldState.Seeded;
   }

   public bool IsWatered()
   {
      return state == TileFieldState.Watered;
   }
}
