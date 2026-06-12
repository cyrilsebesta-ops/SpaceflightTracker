using System;
Console.ForegroundColor = ConsoleColor.Yellow;

CommandHandler commandHandler = new CommandHandler();

Console.WriteLine("=== SPACEFLIGHT TRACKER ===");

while (true)
{
    Console.Write("Command (if you dont know, write: help)> ");

    string command = Console.ReadLine();

    await commandHandler.HandleCommand(command);

    Console.WriteLine();
}