[System.Serializable]
public class GameData
{
    public bool[] selectedCharacter = new bool[3];
    public bool[] selectedJetpack = new bool[3];
    public bool[] selectedShoes = new bool[3];
    public bool[] selectedMap = new bool[3];
    
    public bool[] purchasedCharacter = new bool[3];
    public bool[] purchasedJetpack = new bool[3];
    public bool[] purchasedShoes = new bool[3];
    public bool[] purchasedMap = new bool[3];

    public int coin;

    public int highScore;

    public GameData()
    {
        //Selected items at the first launch
        selectedCharacter[0] = true;
        selectedCharacter[1] = false;
        selectedCharacter[2] = false;

        selectedJetpack[0] = true;
        selectedJetpack[1] = false;
        selectedJetpack[2] = false;

        selectedShoes[0] = true;
        selectedShoes[1] = false;
        selectedShoes[2] = false;

        selectedMap[0] = true;
        selectedMap[1] = false;
        selectedMap[2] = false;

        //Purchased items at the first launch
        purchasedCharacter[0] = true;
        purchasedCharacter[1] = false;
        purchasedCharacter[2] = false;

        purchasedJetpack[0] = true;
        purchasedJetpack[1] = false;
        purchasedJetpack[2] = false;

        purchasedShoes[0] = true;
        purchasedShoes[1] = false;
        purchasedShoes[1] = false;

        purchasedMap[0] = true;
        purchasedMap[1] = false;
        purchasedMap[2] = false;
        
        //Coin and score at the first launch
        coin = 0;
        highScore = 0;
    }
}
