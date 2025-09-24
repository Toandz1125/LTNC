using System;

class Program
{
    static int HexCharToInt(char c)
    {
        if (c >= '0' && c <= '9') return c - '0';
        if (c >= 'A' && c <= 'F') return c - 'A' + 10;
        if (c >= 'a' && c <= 'f') return c - 'a' + 10;
        throw new Exception($"Ký tự '{c}' không hợp lệ trong hệ 16");
    }

    static char IntToHexChar(int value)
    {
        if (value >= 0 && value <= 9) return (char)('0' + value);
        return (char)('A' + (value - 10));
    }

    static int ToDecimal(string value, int baseIn)
    {
        int result = 0;
        foreach (char c in value)
        {
            int digit = (baseIn == 16) ? HexCharToInt(c) : (c - '0');
            if (digit >= baseIn) throw new Exception($"Giá trị '{c}' không hợp lệ trong hệ {baseIn}");
            result = result * baseIn + digit;
        }
        return result;
    }

    static string FromDecimal(int number, int baseOut)
    {
        if (number == 0) return "0";

        string result = "";
        while (number > 0)
        {
            int remainder = number % baseOut;
            char digit = (baseOut == 16) ? IntToHexChar(remainder) : (char)('0' + remainder);
            result = digit + result;
            number /= baseOut;
        }
        return result;
    }
    static int InputChoice(string message)
    {
        int choice;
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out choice) && choice >= 1 && choice <= 3)
            {
                return choice;
            }
            Console.WriteLine("Lỗi: Chỉ được nhập 1, 2 hoặc 3. Vui lòng nhập lại!");
        }
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== CHUYỂN ĐỔI HỆ SỐ ===");

        Console.WriteLine("Chọn hệ số gốc:");
        Console.WriteLine("1. Nhị phân (2)");
        Console.WriteLine("2. Thập phân (10)");
        Console.WriteLine("3. Thập lục phân (16)");
        Console.Write("Lựa chọn: ");
        int baseInChoice = InputChoice("Lựa chọn: ");
        int baseIn = (baseInChoice == 1) ? 2 : (baseInChoice == 2 ? 10 : 16);

        Console.WriteLine("\nChọn hệ số cần xuất:");
        Console.WriteLine("1. Nhị phân (2)");
        Console.WriteLine("2. Thập phân (10)");
        Console.WriteLine("3. Thập lục phân (16)");
        Console.Write("Lựa chọn: ");
        int baseOutChoice = InputChoice("Lựa chọn: ");
        int baseOut = (baseOutChoice == 1) ? 2 : (baseOutChoice == 2 ? 10 : 16);

        Console.Write("\nNhập số cần chuyển đổi: ");
        string inputValue = Console.ReadLine() ?? "0";

        try
        {
            int decimalValue = ToDecimal(inputValue, baseIn);
            string outputValue = FromDecimal(decimalValue, baseOut);

            Console.WriteLine($"\nKết quả: {outputValue}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi: {ex.Message}");
        }
        Console.WriteLine("=== Ấn phím bất kỳ để kết thúc chương trình ===");
        Console.ReadLine();
    }
}
