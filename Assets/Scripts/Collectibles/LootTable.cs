using UnityEngine;

[System.Serializable]
public class LootTable
{
    public GameObject itemPrefab;

    [Range(0f, 100f)]
    public float dropChance;
}
