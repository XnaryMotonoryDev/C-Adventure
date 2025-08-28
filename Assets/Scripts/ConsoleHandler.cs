using TMPro;
using UnityEngine;

public class ConsoleHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField consoleInput;
    [SerializeField] private TMP_Text logText;

    private void Start()
    {
        consoleInput.onEndEdit.AddListener(Parse);
    }

    private void Update()
    {
    }

    private void Parse(string arg)
    {
        var args = arg.Split(new char[] {' '}, System.StringSplitOptions.RemoveEmptyEntries);

        var command = args[0];

        switch (command)
        {
            case "connect":
                if (!ValidateArg(args, 1)) return;
                break;
            default:
                logText.text = "Такой команды нет";
                break;
        }
    }

    private bool ValidateArg(string[] args, int count)
    {
        if (args.Length < count + 1)
        {
            logText.text = "Введите аргумент";
            return false;
        }

        return true;
    }
}