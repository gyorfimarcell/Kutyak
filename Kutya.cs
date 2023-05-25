public class Kutya
{
    string id;
    string fajta;
    string eredetiFajta;
    string nev;
    int eletkor;
    string utolsoEllenorzes;

    public Kutya(string csvSor, List<string[]> nevSorok, List<string[]> fajtaSorok)
    {
        string[] mezok = csvSor.Split(';');
        string[] fajtaSor = fajtaSorok.Find(x => x[0] == mezok[1]);

        this.id = mezok[0];
        this.fajta = fajtaSor[1];
        this.eredetiFajta = fajtaSor[2];
        this.nev = nevSorok.Find(x => x[0] == mezok[2])[1];
        this.eletkor = Convert.ToInt32(mezok[3]);
        this.utolsoEllenorzes = mezok[4];
    }

    public string Id { get => id; }
    public string Fajta { get => fajta; }
    public string EredetiFajta { get => eredetiFajta; }
    public string Nev { get => nev; }
    public int Eletkor { get => eletkor; }
    public string UtolsoEllenorzes { get => utolsoEllenorzes; }
}