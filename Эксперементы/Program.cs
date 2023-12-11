class Proga
{
    static void Main()
    {
        object[][] mas = new object[3][]
        {
            new object[]{1, null, null},
            new object[]{1, 2, 3},
            new object[]{1, 2}
        };
        foreach (var ma in mas)
        {
            Console.WriteLine(string.Join(", ",ma));
        }
    }
}