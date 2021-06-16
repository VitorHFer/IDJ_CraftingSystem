using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormulaManager : MonoBehaviour
{

    public ItemSlot[] topGrid = new ItemSlot[3];
    public ItemSlot[] midGrid = new ItemSlot[3];
    public ItemSlot[] botGrid = new ItemSlot[3];

    private List<ItemSlot[]> allSlots = new List<ItemSlot[]>();

    
    public ItemSlot outputSlot;

    private List<Formula> formulas = new List<Formula>();

    // Start is called before the first frame update
    void Start()
    {
        allSlots.Add(topGrid);
        allSlots.Add(midGrid);
        allSlots.Add(botGrid);

        formulas.AddRange(Resources.LoadAll<Formula>("Formulas/"));
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Formula formula in formulas)
        {
            bool rightPlace = true;

            List<Item[]> allFormulaSlots = new List<Item[]>();
            allFormulaSlots.Add(formula.topGrid);
            allFormulaSlots.Add(formula.midGrid);
            allFormulaSlots.Add(formula.botGrid);

            for(int i = 0; i < 3; i++)
            {
                for(int n = 0; n < allFormulaSlots[i].Length; n++)
                {
                    if(allFormulaSlots[i][n] != null)
                    {
                        if (allSlots[i][n].currentItem !=null)
                        {
                            if(allFormulaSlots[i][n].itemName != allSlots[i][n].currentItem.itemName)
                            {
                                rightPlace = false;
                                //continue;
                            }
                        }
                        else
                        {
                            rightPlace = false;
                            //continue;
                        }
                    }
                    else
                    {
                        if(allSlots[i][n].currentItem != null)
                        {
                            rightPlace = false;
                            continue;

                        }
                    }
                }

                if (rightPlace)
                {
                    outputSlot.currentItem = formula.output;
                    outputSlot.UpdateSlot();
                    break;
                }
                else
                {
                    outputSlot.currentItem = null;
                    outputSlot.UpdateSlot();
                }
            }
        }
    }
}
