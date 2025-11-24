using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("GameManager");
                instance = go.AddComponent<GameManager>();
            }
            return instance;
        }

    }

    public CharacterManager CharacterManager { get; private set; }
    public UIManager UIManager { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeManagers();

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeManagers()
    {
        if (CharacterManager == null)
        {
            var cmobj = new GameObject("CharacterManager");
            CharacterManager = cmobj.AddComponent<CharacterManager>();
        }

        if (UIManager == null)
        {
            var uiobj = new GameObject("UIManager");
            UIManager = uiobj.AddComponent<UIManager>();
        }
    }


}
