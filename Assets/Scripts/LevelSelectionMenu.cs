using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionMenu : MonoBehaviour
{
    public GameConfig gameConfig;
    public PlayerState playerState;
    public GameObject buttonPrefab;
    public Transform gridLayout;

    private void Start()
    {
        GenerateLevelButtons();
    }

    private void GenerateLevelButtons()
    {
        foreach (Transform child in gridLayout)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < gameConfig.labyrinthsStr.Length; i++)
        {
            GameObject button = Instantiate(buttonPrefab, gridLayout);
            button.GetComponentInChildren<Text>().text = "Level " + (i + 1);
            int levelIndex = i;
            button.GetComponent<Button>().onClick.AddListener(() => OnLevelButtonClicked(levelIndex));
        }
    }

    private void OnLevelButtonClicked(int levelIndex)
    {
        playerState.level = levelIndex;
        playerState.Save();
        SceneManager.LoadScene(1);

        Debug.Log("Level " + (levelIndex + 1) + " selected");
    }
}