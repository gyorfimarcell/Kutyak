internal class Program
{
    private static void Main(string[] args)
    {
        List<string[]> nevek = File.ReadAllLines("KutyaNevek.csv").Skip(1).Select(x => x.Split(";")).ToList();
        List<string[]> fajtak = File.ReadAllLines("KutyaFajtak.csv").Skip(1).Select(x => x.Split(";")).ToList();

        List<Kutya> kutyak = File.ReadAllLines("Kutyak.csv").Skip(1).Select(x => new Kutya(x, nevek, fajtak)).ToList();

        Console.WriteLine($"3. feladat: Kutyanevek száma: {nevek.Count}");

        Console.WriteLine($"6. feladat: Kutyák átlag életkora: {kutyak.Average(x => x.Eletkor):f2}");

        Kutya legidosebb = kutyak.Find(x => x.Eletkor == kutyak.Max(x => x.Eletkor));
        Console.WriteLine($"7. feladat: Legidősebb kutya neve és fajtája: {legidosebb.Nev}, {legidosebb.Fajta}");

        Console.WriteLine("8. feladat: január 10.én vizsgált kutya fajták:");
        kutyak.Where(x => x.UtolsoEllenorzes == "2018.01.10").GroupBy(x => x.Fajta).ToList().ForEach(x => Console.WriteLine($"\t{x.Key}: {x.Count()} kutya"));

        var leterhelt = kutyak.GroupBy(x => x.UtolsoEllenorzes).OrderByDescending(x => x.Count()).First();
        Console.WriteLine($"9. feladat: legjobban leterhelt map: {leterhelt.Key}: {leterhelt.Count()} kutya");

        Console.WriteLine("10. feladat: Névsztatisztika.txt");
        File.WriteAllLines("Névsztatisztika.txt", kutyak.GroupBy(x => x.Nev).OrderByDescending(x => x.Count()).Select(x => $"{x.Key};{x.Count()}"));
    }
}