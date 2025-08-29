using System.Linq;
using TMPro;
using UnityEngine;

public class ConsoleHandler : MonoBehaviour
{
    [SerializeField] private ObjectData data;

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
            {
                if (!ValidateArg(args, 1)) return;
                var index = args[1];
                // TODO: refactor method
                if (int.TryParse(index, out var id))
                {
                    var currentInfo = data.infos.FirstOrDefault(info => info.id == id);
                    logText.text = currentInfo.id == id ? "Вы успешно присоединились"
                    : $"Объект с таким индентификатором ({id}) не найден"; // TODO: bug
                }
            }
                break;
            case "find":
                foreach (var info in data.infos)
                {
                    var id = info.id;
                    
                    logText.text = $"ID: {id}";
                    Debug.Log($"ID: {id}");
                
                }
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