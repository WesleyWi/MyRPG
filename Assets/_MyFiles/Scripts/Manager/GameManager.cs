using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager m_Instance;
    [SerializeField] GameObject PlayerPrefab;
    [SerializeField] Transform PlayerSpawn;

    private GameObject Player;
    [SerializeField] private PartyManager Party;
    [SerializeField] private BattleManager CurrentBattle;

    bool bDebugToggle = false;

    public void Awake()
    {
        if (m_Instance != null && m_Instance != this)
        {
            Debug.LogError("Multiple GameManager found. Detecting copy...");
            Destroy(this);        
        }
        else
        {
            m_Instance = this;
        }
    }

    private void Start()
    {
        if (PlayerPrefab)
        {
            //Spawn Player
            GameObject playerGRP = Instantiate(PlayerPrefab, PlayerSpawn.transform.position, PlayerSpawn.transform.rotation);
            Player = playerGRP.GetComponentInChildren<UnitCharacter>().gameObject;
            CreatePartyManager();

        }
        else
        {
            Debug.LogWarning("PlayerPrefab or PlayerSpawn not referenced.");
        }
    }

    public GameObject GetPlayer()
    { return Player; }

    public int DiceRoll()
    {
        int dicRoll = Random.Range(1, 20 + 1);
        return dicRoll;
    }

    public void CreatePartyManager()
    {
        if (Player) { return; }
        Party = gameObject.AddComponent<PartyManager>();

    }
    public void DestroyPartyManager()
    {
        Destroy(Party);
        Party = null;
    }
    public PartyManager GetPartyManager() { return Party; }
    public void CreateBattleManager(List<GameObject> enemyBattleList)
    {
        if (CurrentBattle) { return; }

        Debug.Log("Creating BattleManager");
        CurrentBattle = gameObject.AddComponent<BattleManager>();
        CurrentBattle.InitializeBattle(enemyBattleList);

    }
    public void DestroyBattleManager()
    {
        Destroy(CurrentBattle);
        CurrentBattle = null;
    }
    public BattleManager GetBattleManager() { return CurrentBattle; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (bDebugToggle)
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState= CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public void SaveData()
    {
        Debug.Log("Saving Data...");
        string playerData = JsonUtility.ToJson(Player.GetComponent<UnitCharacter>().GetCharacterStats());
        string filePath = Application.persistentDataPath + "/PlayerData.json";
        Debug.Log(filePath);
        Debug.Log("Save Complete");

    }

    public void LoadData()
    {
        Debug.Log("Loading Data...");
        string filePath = Application.persistentDataPath + "/PlayerData.json";
        string playerData = System.IO.File.ReadAllText(filePath);
        JsonUtility.FromJsonOverwrite(playerData, Player.GetComponent<UnitCharacter>().GetCharacterStats());
        Debug.Log("Load Complete!");

    }
}
