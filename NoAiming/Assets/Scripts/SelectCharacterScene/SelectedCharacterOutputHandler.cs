using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectedCharacterOutputHandler : MonoBehaviour
{
    [Header("雙方選擇器")]
    [SerializeField] private GameObject characterGroup1;
    [SerializeField] private GameObject characterGroup2;

    //玩家選擇之角色的名字
    private string player1Character;
    private string player2Character;
    public string player1CharacterGetter()
    {
        return player1Character;
    }
    public string player2CharacterGetter()
    {
        return player2Character;
    }
    
    public void Update()
    {
        for (int i = 0; i < characterGroup1.transform.childCount; i++)
        {
            if (characterGroup1.transform.GetChild(i).gameObject.activeSelf == true)
            {
                player1Character = characterGroup1.transform.GetChild(i).gameObject.name;
                break;
            }
        }

        for (int i = 0; i < characterGroup2.transform.childCount; i++)
        {
            if (characterGroup2.transform.GetChild(i).gameObject.activeSelf == true)
            {
                player2Character = characterGroup2.transform.GetChild(i).gameObject.name;
                break;
            }
        }

        DontDestroyOnLoad(this);
    }
}
