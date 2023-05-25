internal class Program
{
    private static void Main(string[] args)
    {
        List<string[]> nevek = File.ReadAllLines("KutyaNevek.csv").Skip(1).Select(x => x.Split(";")).ToList();
        List<string[]> fajtak = File.ReadAllLines("KutyaFajtak.csv").Skip(1).Select(x => x.Split(";")).ToList();

        List<Kutya> kutyak = File.ReadAllLines("Kutyak.csv").Skip(1).Select(x => new Kutya(x, nevek, fajtak)).ToList();

        Console.WriteLine($"3. feladat: Kutyanevek száma: {nevek.Count}");
    }
}