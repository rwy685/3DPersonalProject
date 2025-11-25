using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    public CharacterManager characterManager { get; private set; }
    public UIManager uiManager { get; private set; }
    public DataManager dataManager { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            characterManager = GetComponent<CharacterManager>();
            uiManager = GetComponent<UIManager>();
            dataManager = new DataManager();

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        characterManager.CreatePlayer();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        uiManager.InitUI();
    }
}

