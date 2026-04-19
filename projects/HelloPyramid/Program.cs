namespace HelloPyramid;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string phrase = "HELLO WORLD";
        int pyramidHeight = 13;
        int diamondHeight = 9;

        ConsoleColor[] rainbow =
        [
            ConsoleColor.Red,
            ConsoleColor.DarkYellow,
            ConsoleColor.Yellow,
            ConsoleColor.Green,
            ConsoleColor.Cyan,
            ConsoleColor.Blue,
            ConsoleColor.Magenta
        ];

        // === Phase 1: Rising Pyramid ===
        Console.WriteLine();
        int charIndex = 0;
        for (int row = 0; row < pyramidHeight; row++)
        {
            int width = row * 2 + 1;
            int padding = pyramidHeight - row - 1;

            Console.Write(new string(' ', padding));

            for (int col = 0; col < width; col++)
            {
                if (col == 0 || col == width - 1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("*");
                }
                else
                {
                    char c = phrase[charIndex % phrase.Length];
                    Console.ForegroundColor = rainbow[charIndex % rainbow.Length];
                    Console.Write(c);
                    charIndex++;
                }
            }

            Console.WriteLine();
        }

        // === Base line ===
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(new string('*', pyramidHeight * 2 - 1));

        Console.WriteLine();

        // === Phase 2: Diamond with HELLO WORLD ===
        int maxWidth = diamondHeight;
        charIndex = 0;

        // Upper half
        for (int row = 0; row < maxWidth; row++)
        {
            int width = row * 2 + 1;
            int padding = maxWidth - row;
            Console.Write(new string(' ', padding));

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("/");

            for (int col = 0; col < width; col++)
            {
                char c = phrase[charIndex % phrase.Length];
                Console.ForegroundColor = rainbow[(row + col) % rainbow.Length];
                Console.Write(c);
                charIndex++;
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\\");
            Console.WriteLine();
        }

        // Middle line
        int midWidth = maxWidth * 2 + 1;
        Console.Write(" ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("<");
        for (int i = 0; i < midWidth; i++)
        {
            char c = phrase[charIndex % phrase.Length];
            Console.ForegroundColor = rainbow[i % rainbow.Length];
            Console.Write(c);
            charIndex++;
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(">");
        Console.WriteLine();

        // Lower half
        for (int row = maxWidth - 1; row >= 0; row--)
        {
            int width = row * 2 + 1;
            int padding = maxWidth - row;
            Console.Write(new string(' ', padding));

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\\");

            for (int col = 0; col < width; col++)
            {
                char c = phrase[charIndex % phrase.Length];
                Console.ForegroundColor = rainbow[(row + col) % rainbow.Length];
                Console.Write(c);
                charIndex++;
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("/");
            Console.WriteLine();
        }

        Console.WriteLine();

        // === Phase 3: Inverted pyramid (reflection) ===
        for (int row = pyramidHeight - 1; row >= 0; row--)
        {
            int width = row * 2 + 1;
            int padding = pyramidHeight - row - 1;

            Console.Write(new string(' ', padding));

            for (int col = 0; col < width; col++)
            {
                if (col == 0 || col == width - 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(".");
                }
                else
                {
                    char c = phrase[charIndex % phrase.Length];
                    Console.ForegroundColor = rainbow[charIndex % rainbow.Length];
                    Console.Write(c);
                    charIndex++;
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine();

        // === Phase 4: Banner ===
        Console.ForegroundColor = ConsoleColor.Cyan;
        string banner = "~ H E L L O   W O R L D ~";
        int bannerPad = (pyramidHeight * 2 - 1 - banner.Length) / 2;
        if (bannerPad < 0) bannerPad = 0;
        Console.Write(new string(' ', bannerPad));

        for (int i = 0; i < banner.Length; i++)
        {
            Console.ForegroundColor = rainbow[i % rainbow.Length];
            Console.Write(banner[i]);
        }
        Console.WriteLine();
        Console.WriteLine();

        Console.ResetColor();
    }
}
