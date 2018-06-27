using Homebrew;

[System.Serializable]
public struct DataTag
{
    [TagFilter(typeof(Tag))] public int id;
}