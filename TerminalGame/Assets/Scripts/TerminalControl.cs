using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalControl : MonoBehaviour
{
    enum Screen
    {
        mainMenu,
        password,
        Win
    };
    Screen currentScreen;

    const string menuHint = "Напишите меню, чтобы вернуться в меню";

    int level;
    string password;
    string[] level1Password = {"Марио","Луиджи","Пич"};
    string[] level2Password = { "Том Нук", "Изабель", "Гулливер"};
    string[] level3Password = { "Линк", "Зельда", "Ганандорф"};

    void Start()
    {
        ShowMainMenu("Пользователь");
    }

    void ShowMainMenu(string playerName)
    {
        currentScreen = Screen.mainMenu;
        level = 0;
        Terminal.ClearScreen();
        Terminal.WriteLine("Добрый день! "+playerName+"." + "\nКакой терминал вы хотите взломать сегодня?" +
            "\n\nВведите 1 - Super Mario Bros" +
            "\nВведите 2 - Animal Crossing" +
            "\nВведите 3 - The legend of Zelda" +
            "\nВаш выбор: ");
    }

    void OnUserInput(string input)
    {
        if (input == "меню")
        {
            ShowMainMenu("Рад видеть тебя снова!");
        }
        else if (currentScreen == Screen.mainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.password)
        {
            Terminal.WriteLine("Введите пароль");
            CheckPassword(input);
        }

    }

    void RunMainMenu(string input)
    {
        bool isValuideLevelNumber = (input == "1" || input == "2"
            || input == "3");

        if (isValuideLevelNumber)
        {
            level = int.Parse(input);
            GameStart();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Hello Mr.Bond!");
        }
        else if (input == "Писька")
        {
            Terminal.WriteLine("Кроп лучший!");
        }
    }

    void GameStart()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.password;

        switch (level)
        {
            case 1:
        password = level1Password[Random.Range(0, level1Password.Length)];
                Terminal.WriteLine("Главные герои серии игр про Марио?");
                break;
            case 2:
        password = level2Password[Random.Range(0, level2Password.Length)];
                Terminal.WriteLine("Главные герои серии игр Animal Crossing?");
                break;
            case 3:
        password = level3Password[Random.Range(0, level3Password.Length)];
                Terminal.WriteLine("Главные герои серии The Legend of Zelda?");
                break;
        default:
        Debug.LogError("Такого уровня не существует!");
        break;
        }
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("Подсказка: "+ password.Anagram());

    }
    void CheckPassword(string input)
    {
        if (input == password)
        {
            ShowWinScreen();
        }
        else
        {
            GameStart();
        }
    }
    void ShowWinScreen()
    {
        Terminal.ClearScreen();
        Revard();
    }
    void Revard()
    {
        currentScreen = Screen.Win;
        switch (level)
        {
            case 1:
                Terminal.WriteLine(
@"

░░░█████
░░█▒▒▒▒▒█
░█▒▒▒▒▒M▒█
░███████████
╔═██░╔═░═░
║▒██░║█░█░═╗
╚═░░██░░░░░║    .--------------.
██║░░██████╝   ( Пароль верный! )
░░╚═══════╝ --/ `--------------'
");

                break;
            case 2:
                Terminal.WriteLine(
@"
    /\_____/\     .--------------.
   /  o   o  \   ( Пароль верный! )
  ( ==  ^  == )--/`--------------'
   )         (
  (           )
 ( (  )   (  ) )
(__(__)___(__)__)
");
                break;
            case 3:
                Terminal.WriteLine(
@"
.'.         .'.
|  \       /  | Hey! Listen!
'.  \  |  /  .'
  '. \\|// .'   Пароль верный!
    '-- --'  
    .'/|\'.
   '..'|'..'⠀⠀⠀
");
                break;
        }
        Terminal.WriteLine(menuHint);
    }
}
