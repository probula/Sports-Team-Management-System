// See https://aka.ms/new-console-template for more information


interface IPlayer
{
    string Name { get; set; }
    string Position { get; set; }
    int Score { get; set; }
}
class Player : IPlayer
{
    public string Name {get; set;}
    public string Position {get; set;}
    public int Score {get; set;}

    public Player(string name, string position)
    {
        Name = name;
        Position = position;
        Score = 0;

    }

    public void ScoreUpdate()
    {
        Console.WriteLine("Podaj wynik zawodnika");
        Score = int.Parse(Console.ReadLine());
    }

    public void Szukaj()
    {
        
    }
}

class Team
{
    public List<IPlayer> Players = new List<IPlayer>();
    
    public void Dodaj()
    {
        Console.WriteLine("Ile zawodników chcesz dodać?: ");
        int ilosc = int.Parse(Console.ReadLine());
        

        for (int i = 0; i < ilosc; i++)
        {
            Console.WriteLine("Podaj nazwe zawodnika");
            string nazwa = Console.ReadLine();
            
            Console.WriteLine("Podaj pozycje zawodnika?: ");
            string pozycja = Console.ReadLine();
            
            Players.Add(new Player(nazwa, pozycja));
        }
    }

    public void Usun()
    {
        
    }

    public void Wyswietl()
    {
        Console.WriteLine("Statystyki drużyny: ");
        foreach (var player in Players)
        {
            
        }
    }
}
internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}