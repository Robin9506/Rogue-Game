using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    #region Header OBJECT REFERENCES
    [Space(10)]
    [Header("OBJECT REFERENCES")]
    #endregion Header OBJECT REFERENCES
    #region Tooltip
    [Tooltip("Populate with the enter the dungeon play button gameobject")]
    #endregion Tooltip
    [SerializeField] private GameObject playButton;
    #region Tooltip
    [Tooltip("Populate with the quit button gameobject")]
    #endregion
    [SerializeField] private GameObject quitButton;
    #region Tooltip
    [Tooltip("Populate with the high scores button gameobject")]
    #endregion
    [SerializeField] private GameObject highScoresButton;
    #region Tooltip
    [Tooltip("Populate with the instructions button gameobject")]
    #endregion
    [SerializeField] private GameObject instructionsButton;
    #region Tooltip
    [Tooltip("Populate with the return to main menu button gameobject")]
    #endregion
    [SerializeField] private GameObject returnToMainMenuButton;
    private bool isInstructionSceneLoaded = false;
    private bool isHighScoresSceneLoaded = false;

    private void Start()
    {
        // Play Music
        MusicManager.Instance.PlayMusic(GameResources.Instance.mainMenuMusic, 0f, 2f);

        SceneManager.LoadScene("CharacterSelectorScene", LoadSceneMode.Additive);

        returnToMainMenuButton.SetActive(false);
    }

    /// <summary>
    /// Called from the Play Game / Enter The Dungeon Button
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void LoadHighScores()
    {
        playButton.SetActive(false);
        quitButton.SetActive(false);
        highScoresButton.SetActive(false);
        instructionsButton.SetActive(false);
        isHighScoresSceneLoaded = true;

        SceneManager.UnloadSceneAsync("CharacterSelectorScene");

        returnToMainMenuButton.SetActive(true);

        // Load High Score scene additively
        SceneManager.LoadScene("HighScoreScene", LoadSceneMode.Additive);
    }

    public void LoadCharacterSelector()
    {
        returnToMainMenuButton.SetActive(false);

        if (isHighScoresSceneLoaded)
        {
            SceneManager.UnloadSceneAsync("HighScoreScene");
            isHighScoresSceneLoaded = false;
        }
        else if (isInstructionSceneLoaded)
        {
            SceneManager.UnloadSceneAsync("InstructionScene");
            isInstructionSceneLoaded = false;
        }

        playButton.SetActive(true);
        quitButton.SetActive(true);
        highScoresButton.SetActive(true);
        instructionsButton.SetActive(true);

        // Load character selector scene additively
        SceneManager.LoadScene("CharacterSelectorScene", LoadSceneMode.Additive);
    }

    public void LoadInstructions()
    {
        playButton.SetActive(false);
        quitButton.SetActive(false);
        highScoresButton.SetActive(false);
        instructionsButton.SetActive(false);
        isInstructionSceneLoaded = true;

        SceneManager.UnloadSceneAsync("CharacterSelectorScene");

        returnToMainMenuButton.SetActive(true);

        // Load instructions scene additively
        SceneManager.LoadScene("InstructionScene", LoadSceneMode.Additive);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
