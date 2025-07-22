namespace Knapsack;

public static class Knapsack
{
    public static int MaximumValue(int maximumWeight, (int weight, int value)[] items)
    {
        if (items.Length == 0)
        {
            return 0;
        }

        (int weightOfAllItems, int valueOfAllItems) = items.Aggregate(((int weight, int value) total, (int weight, int value) el) => (total.weight + el.weight, total.value + el.value));
        if (weightOfAllItems <= maximumWeight)
        {
            return valueOfAllItems;
        }

        int result = 0;

        List<(int sackWeight, int sackValue)> currentNodes = [(0, 0)];
        for (int i = 0; i < items.Length; ++i)
        {
            List<(int sackWeight, int sackValue)> newNodes = [];

            foreach (var node in currentNodes)
            {
                newNodes.Add(node);
                if (node.sackWeight + items[i].weight <= maximumWeight)
                {
                    newNodes.Add(node with { sackWeight = node.sackWeight + items[i].weight, sackValue = node.sackValue + items[i].value });
                }
            }

            currentNodes.Clear();
            currentNodes.AddRange(newNodes);
            result = Math.Max(result, newNodes.Max(variation => variation.sackValue));
        }

        return result;
    }
}
