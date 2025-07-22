namespace Knapsack;

public static class Knapsack
{
    public static int MaximumValue(int maximumWeight, (int weight, int value)[] items)
    {
        int res = 0;
        int numberOfCombinations = Convert.ToInt32(Math.Pow(2, items.Length));

        for (int combinationSet = numberOfCombinations; combinationSet > 0; --combinationSet)
        {
            int weightInPack = 0;
            int valueInPack = 0;

            for (int j = 0; j < items.Length; ++j)
            {
                int itemInSet = Convert.ToInt32(Math.Pow(2, j));

                if ((itemInSet & combinationSet) == itemInSet)
                {
                    weightInPack += items[j].weight;
                    valueInPack += items[j].value;

                    // reset value calculation for combination if we already over the weight limit
                    if (weightInPack > maximumWeight)
                    {
                        valueInPack = 0;
                        break;
                    }
                }
            }

            if (valueInPack > res)
            {
                res = valueInPack;
            }
        }

        return res;
    }
}
