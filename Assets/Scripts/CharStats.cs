using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public string charName;
    public int playerLevel = 1;
    public int currentEXP;
    public int[] expToNextLevel;
    public int maxLevel = 100;
    public int baseEXP = 1000;

    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 30;
    public int[] mpLvlBonus;
    public int strength;
    public int defence;
    public int wpnPwr;
    public int armrPwr;
    public string equippedWpn;
    public string equippedArmr;
    public Sprite charImage;

    // Start is called before the first frame update
    void Start()
    {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP;

        for (int i = 2; i < expToNextLevel.Length; i++)
        {
            //change number beside f to change exp curve to next levels
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //testing exp gain, lvl up and stats increases by pressing K
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddExp(1000);
        }
    }

    public void AddExp(int expToAdd)
    {
        currentEXP += expToAdd;

        if (playerLevel < maxLevel)
        {
            if (currentEXP > expToNextLevel[playerLevel])
            {
                currentEXP -= expToNextLevel[playerLevel];

                playerLevel++;
                //each way to increase stats below can be used for any stats.
                //determine whether to add 1 to str or def based on odd or even
                if (playerLevel % 2 == 0)
                {
                    strength++;
                }
                else
                {
                    defence++;
                }
                //change number beside f to change HP curve to next levels
                maxHP = Mathf.FloorToInt(maxHP * 1.05f);
                currentHP = maxHP;
                //add MP you can choose manually in Unity
                maxMP += mpLvlBonus[playerLevel];
                currentMP = maxMP;
            }
        }

        if(playerLevel >= maxLevel)
        {
            currentEXP = 0;
        }
    }
}
