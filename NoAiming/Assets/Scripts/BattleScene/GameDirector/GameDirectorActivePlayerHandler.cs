using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirectorActivePlayerHandler : MonoBehaviour
{
    //儲存SelectedCharacterOutput的SelectedCharacterOutputHandler物件
    private SelectedCharacterOutputHandler output;

    //儲存SelectedCharacterOutputHandler雙方的角色名稱
    private string player1Character;
    private string player2Character;

    [Header("雙方角色母群體")]
    [SerializeField] private GameObject player1Group;
    [SerializeField] private GameObject player2Group;

    //將指定的角色激活，用名字指定
    public void ActivePlayer(string player1Character, string player2Character)
    {
        for (int i = 0; i < player1Group.transform.childCount; i++)
        {
            if (player1Group.transform.GetChild(i).gameObject.name == player1Character)
            {
                player1Group.transform.GetChild(i).gameObject.SetActive(true);
                break;
            }
        }

        for (int i = 0; i < player2Group.transform.childCount; i++)
        {
            if (player2Group.transform.GetChild(i).gameObject.name == player2Character)
            {
                player2Group.transform.GetChild(i).gameObject.SetActive(true);
                break;
            }
        }
    }
    private void Awake()
    {
        //將SelectedCharacterOutput的SelectedCharacterOutputHandler物件存入output
        output = FindObjectOfType<SelectedCharacterOutputHandler>();

        //將SelectedCharacterOutputHandler的雙方名字個別存入
        player1Character = output.player1CharacterGetter();
        player2Character = output.player2CharacterGetter();

        //將雙方角色激活
        ActivePlayer(player1Character, player2Character);
    }

    private void Start()
    {
        //處理完事後，將傳達訊息的SelectedCharacterOutput刪掉
        Destroy(output.gameObject);
    }

}
