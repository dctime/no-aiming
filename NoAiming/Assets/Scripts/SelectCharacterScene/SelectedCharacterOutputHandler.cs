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
        //得到character1Group裡被激活的角色
        for (int i = 0; i < characterGroup1.transform.childCount; i++)
        {
            if (characterGroup1.transform.GetChild(i).gameObject.activeSelf == true)
            {
                //當找到被激活的角色時，將其名字存入player1Character
                player1Character = characterGroup1.transform.GetChild(i).gameObject.name;
                break;
            }
        }

        //得到character2Group裡被激活的角色
        for (int i = 0; i < characterGroup2.transform.childCount; i++)
        {
            if (characterGroup2.transform.GetChild(i).gameObject.activeSelf == true)
            {
                //當找到被激活的角色時，將其名字存入player2Character
                player2Character = characterGroup2.transform.GetChild(i).gameObject.name;
                break;
            }
        }

        //此物件是不能因切換物件被破壞
        DontDestroyOnLoad(this);
    }
}
