using System.Diagnostics;


while (true)
{
    Console.WriteLine("1. Показать все процессы");
    Console.WriteLine("2. Завершить процесс по ID");
    Console.WriteLine("3. Выход");
    Console.Write("Выберите действие: ");

    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            ShowProcesses();
            break;
        case "2":
            Console.Write("Введите ID процесса: ");
            var idInput = Console.ReadLine();
            if (int.TryParse(idInput, out var processId))
            {
                KillProcess(processId);
            }
            else
            {
                Console.WriteLine("Некорректный ID процесса");
            }

            break;
        case "3":
            return;
        default:
            Console.WriteLine("Некорректный ввод");
            break;
    }
}

static void ShowProcesses()
{
    var processes = Process.GetProcesses();
    foreach (var process in processes)
    {
        Console.WriteLine($"ID: {process.Id}, Name: {process.ProcessName}");
    }
}

static void KillProcess(int id)
{
    try
    {
        var process = Process.GetProcessById(id);
        process.Kill();
        Console.WriteLine($"Процесс с ID {id} был завершен");
    }
    catch (ArgumentException)
    {
        Console.WriteLine($"Процесс с ID {id} не найден");
    }
    catch (InvalidOperationException)
    {
        Console.WriteLine($"Процесс с ID {id} уже завершен");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Произошла ошибка: {ex.Message}");
    }
}