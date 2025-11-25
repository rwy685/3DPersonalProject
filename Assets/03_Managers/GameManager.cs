using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }


    public CharacterManager characterManager { get; private set; }
    public UIManager uiManager { get; private set; }
    public DataManager dataManager { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            characterManager = GetComponent<CharacterManager>();
            uiManager = GetComponent<UIManager>();
            dataManager = new DataManager();
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
}
