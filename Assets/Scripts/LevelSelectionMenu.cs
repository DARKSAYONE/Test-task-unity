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
    public GameObject selectMenu;
    [SerializeField] private GameObject LevelsPanel;

    private void Start()
    {
        GenerateLevelButtons();
    }

    private void GenerateLevelButtons()
    {
        foreach (Transform child in LevelsPanel.transform)
        {
            Destroy(child.gameObject);
        }

        int numberOfLevels = Mathf.CeilToInt(gameConfig.labyrinthsStr.Length / (float)gameConfig.wavesCount);

        for (int i = 0; i < numberOfLevels; i++)
        {
            GameObject button = Instantiate(buttonPrefab, LevelsPanel.transform);
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
    }

    public void ToggleMenu()
    {
        selectMenu.SetActive(!selectMenu.activeSelf);
    }
}


