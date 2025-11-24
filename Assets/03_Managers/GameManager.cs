using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;


    public CharacterManager characterManager { get; private set; }
    public UIManager uiManager { get; private set; }
    public DataManager dataManager { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            characterManager = new CharacterManager();
            dataManager = new DataManager();
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
