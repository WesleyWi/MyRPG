using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    [SerializeField] List<GameObject> PartyList = new List<GameObject>();

    private void Awake()
    {
        GatherParty();
    }

    public void GatherParty()
    {
        //Gather party creation
    }
    public List<GameObject> GetPartyList() { return PartyList; }
    public void AddPartyMember(UnitCharacter partyMember)
    {
        if (partyMember != null)
        {
            if (partyMember)
            {
                PartyList.Add(partyMember.gameObject);
            }
        }
    }
}
