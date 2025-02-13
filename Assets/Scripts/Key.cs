using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool isCollected = false;

    private void Awake()
    {
        LabyrinthKey labyrinthKey = GetComponentInParent<LabyrinthKey>();
        if (labyrinthKey != null)
        {
            labyrinthKey.RegisterKey(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isCollected && other.GetComponent<Ball>() != null)
        {
            isCollected = true;
            LabyrinthKey.Instance.CollectKey(gameObject);
            Debug.Log("Key trigger activated by Ball.");
        }
    }
}