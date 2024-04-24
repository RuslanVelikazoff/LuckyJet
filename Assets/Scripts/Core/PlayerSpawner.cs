using System.Collections;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characters;
    [SerializeField] 
    private GameObject[] jetpacks;
    [SerializeField] 
    private GameObject[] leftShoes;
    [SerializeField] 
    private GameObject[] rightShoes;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.1f);
        
        SetCharacter();
        SetJetpack();
        SetShoes();
    }

    private void SetCharacter()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (i == Data.Instance.GetCharacterIndex())
            {
                characters[i].SetActive(true);
            }
            else
            {
                characters[i].SetActive(false);
            }
        }
    }

    private void SetJetpack()
    {
        for (int i = 0; i < jetpacks.Length; i++)
        {
            if (i == Data.Instance.GetJetpackIndex())
            {
                jetpacks[i].SetActive(true);
            }
            else
            {
                jetpacks[i].SetActive(false);
            }
        }
    }

    private void SetShoes()
    {
        for (int i = 0; i < leftShoes.Length; i++)
        {
            if (i == Data.Instance.GetShoesIndex())
            {
                leftShoes[i].SetActive(true);
                rightShoes[i].SetActive(true);
            }
            else
            {
                leftShoes[i].SetActive(false);
                rightShoes[i].SetActive(false);
            }
        }
    }
}
