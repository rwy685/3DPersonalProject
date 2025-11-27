using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    public CharacterManager characterManager { get; private set; }
    public HUDManager hudManager { get; private set; }
    public DataManager dataManager { get; private set; }

    // UIManager는 전역이 아니라 씬 전용
    public UIManager uiManager { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // 전역 매니저 로드
        characterManager = GetComponent<CharacterManager>();
        hudManager = GetComponent<HUDManager>();
        dataManager = new DataManager();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 1) MainScene에서만 Player 생성
        if (scene.name == "MainScene")
        {
            if (characterManager.player == null)
                characterManager.CreatePlayer();

            // 2) 저장된 데이터 적용
            if (dataManager.cachedLoadData != null)
            {
                characterManager.player.ApplyLoadedData(dataManager.cachedLoadData);
                dataManager.cachedLoadData = null;
            }
        }

        // Scene 전용 UI 관련
        uiManager = FindObjectOfType<UIManager>();
        if (uiManager != null)
            uiManager.InitUI();

        hudManager.FindHUDInScene();
        if (hudManager.HasHUD && characterManager.player != null)
            hudManager.Init(characterManager.player.status);
    }

}


