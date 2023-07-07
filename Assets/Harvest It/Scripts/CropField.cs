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

   private void Start()
   {
      StoreTiles();
   }

   private void StoreTiles()
   {
      for (int i = 0; i < tilesParent.childCount; i++)
      {
         croptiles.Add(tilesParent.GetChild(i).GetComponent<CropTile>());
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
}
