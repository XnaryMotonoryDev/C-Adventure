using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "TextStuff", menuName = "Data/Stuff")]
public class TextStuff : ScriptableObject
{
    public CommandStuff[] commandStuff;

    public CommandStuff GetStuff(CommandStuff.Commands commands)
    {
        return commandStuff.FirstOrDefault(cmd => cmd.command == commands);
    }
}

[System.Serializable]
public class CommandStuff
{
    public Commands command;
    [TextArea(1, 2)] public string apllyMassage;
    [TextArea(1, 2)] public string warningMassage;
    [TextArea(1, 2)] public string errorMassage;

    public enum Commands
    {
        FIND,
        CONNECT,
        USE
    }
}