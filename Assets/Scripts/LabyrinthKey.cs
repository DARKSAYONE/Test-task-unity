using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabyrinthKey : Labyrinth
{
    [SerializeField] private List<GameObject> keys = new List<GameObject>();
    [SerializeField] private GameObject door;

    public int keysCollected = 0;
    public int totalKeys;

    public static LabyrinthKey Instance { get; private set; }

    private GameObject keyCounterUI;
    private Text keyCounterText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Level level = GetComponentInParent<Level>();
        if (level != null)
        {
            keyCounterUI = level.keyCounterUI;
            keyCounterText = level.keyCounterText;
            keyCounterUI.SetActive(true);
        }
        UpdateKeyCounter();
    }

    public void RegisterKey(GameObject key)
    {
        keys.Add(key);
        totalKeys = keys.Count;
        UpdateKeyCounter();
    }

    public void CollectKey(GameObject key)
    {
        keysCollected++;
        keys.Remove(key);
        Destroy(key);
        Debug.Log($"Key collected. Total keys collected: {keysCollected}/{totalKeys}");
        UpdateKeyCounter();

        if (keysCollected >= totalKeys)
        {
            OpenDoor();
        }
    }

    private void UpdateKeyCounter()
    {
        if (keyCounterText != null)
        {
            keyCounterText.text = $"Keys: {keysCollected}/{totalKeys}";
        }
    }

    private void OpenDoor()
    {
        door.SetActive(false);
        Debug.Log("Door opened.");
    }
}