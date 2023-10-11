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
            Player = Instantiate(PlayerPrefab, PlayerSpawn.transform.position, PlayerSpawn.transform.rotation);
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
}
