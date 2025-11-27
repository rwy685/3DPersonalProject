using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SaveButton : MonoBehaviour
{
    public Button saveButton;
    public TextMeshProUGUI messageText; // 선택사항

    private void Awake()
    {
        saveButton.onClick.RemoveAllListeners();
        saveButton.onClick.AddListener(OnClickSave);
    }

    private void OnClickSave()
    {
        var gm = GameManager.Instance;
        var player = gm.characterManager.player;

        gm.dataManager.SaveAll(
            player.status,
            player.inventory,
            player.equipmentManager
        );

        if (messageText != null)
        {
            messageText.text = "저장완료 2초 뒤 로딩신으로";
        }

        Debug.Log("세이브 완료");

        StartCoroutine(ReturnToLoading());
    }

    IEnumerator ReturnToLoading()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("LoadingScene");
    }
}

