using UnityEngine;

[CreateAssetMenu(fileName = "ObjectData", menuName = "Data/Object")]
public class ObjectData : ScriptableObject
{
    public ObjectInfo[] infos;
}

[System.Serializable]
public class ObjectInfo
{
    public int id;
}