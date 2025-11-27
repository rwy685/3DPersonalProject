using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadButton : MonoBehaviour
{
    public Button newButton;
    public Button loadButton;
    public TextMeshProUGUI messageText;

    private void Awake()
    {
        newButton.onClick.RemoveAllListeners();
        loadButton.onClick.RemoveAllListeners();

        newButton.onClick.AddListener(OnClickNew);
        loadButton.onClick.AddListener(OnClickLoad);
    }

    private void OnClickNew()
    {
        var gm = GameManager.Instance;

        gm.dataManager.ClearSave();
        gm.dataManager.isNewGame = true;    // New 게임 플래그 설정

        messageText.text = "새 게임 시작 2초 뒤 다음 신으로";
        StartCoroutine(GoMainScene());
    }

    private void OnClickLoad()
    {
        var gm = GameManager.Instance;

        var data = gm.dataManager.LoadAll();
        if (data == null)
        {
            messageText.text = "저장된 데이터 없음";
            return;
        }

        gm.dataManager.cachedLoadData = data;
        gm.dataManager.isNewGame = false;  // Load 게임 플래그 설정

        messageText.text = "불러오기 성공";
        StartCoroutine(GoMainScene());
    }

    private IEnumerator GoMainScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainScene");
    }
}

