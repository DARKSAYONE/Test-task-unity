using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthFruit : Labyrinth
{
    [SerializeField] private GameObject[] fruitPrefabs;

    public void ReplaceBallModels(List<Ball> balls)
    {
        foreach (var ball in balls)
        {
            var meshFilter = ball.GetComponent<MeshFilter>();
            var meshRenderer = ball.GetComponent<MeshRenderer>();
            if (meshFilter != null && meshRenderer != null && fruitPrefabs.Length > 0)
            {
                int randomIndex = Random.Range(0, fruitPrefabs.Length);
                var fruitPrefab = fruitPrefabs[randomIndex];
                var fruitMeshFilter = fruitPrefab.GetComponent<MeshFilter>();
                var fruitMeshRenderer = fruitPrefab.GetComponent<MeshRenderer>();

                if (fruitMeshFilter != null && fruitMeshRenderer != null)
                {
                    meshFilter.mesh = fruitMeshFilter.sharedMesh;
                    meshRenderer.sharedMaterial = fruitMeshRenderer.sharedMaterial;
                }
            }
        }
    }
}

