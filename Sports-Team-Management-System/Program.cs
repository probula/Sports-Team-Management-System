// See https://aka.ms/new-console-template for more information


interface IPlayer
{
    string Name { get; set; }
    string Position { get; set; }
    int Score { get; set; }
    void PlayerInfo();
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
        int wynik = int.Parse(Console.ReadLine());

        Score = wynik;
    }
    
    public void PlayerInfo()
    {
        Console.WriteLine($"Zawodnik: {Name}, Pozycja: {Position}, Punkty: {Score}");
    }
    
    public static Player SzukajZawodnika(List<Player> players, string position)
    {
       return players.Find(x => x.Position == position);
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
        Console.WriteLine("Podaj nazwę zawodnika do usunięcia:");
        string nazwa = Console.ReadLine();
        var usunZawodnika = Players.Find(p => p.Name == nazwa);
        if (usunZawodnika != null)
        {
            Players.Remove(usunZawodnika);
            Console.WriteLine($"Zawodnik {nazwa} został usunięty.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono zawodnika o podanej nazwie.");
        }
    }

    public void Wyswietl()
    {
        Console.WriteLine("Statystyki drużyny: ");
        foreach (var player in Players)
        {
            player.PlayerInfo();
        }
    }

    public void StatystykiDruzyny()
    {
        Console.WriteLine("Statystyki drużyny: ");
        foreach (var player in Players)
        {
            player.PlayerInfo();
        }
    }

    public static double SredniaPkt(List<IPlayer> players)
    {
        return players.Average(x => x.Score);
    }
    
    
    
}
internal class Program
{
    public static void Main(string[] args)
    {
        Team team = new Team();
        team.Dodaj();
        
        Console.WriteLine("Podaj z jakiej pozycji maja byc zawodnik:");
        string pozycja = Console.ReadLine();
        var players = team.Players.Cast<Player>().ToList(); //cast - konwersja List<Player>
        
        var player = Player.SzukajZawodnika(players, pozycja);
        if (player != null)
        {
            Console.WriteLine("Zawodnicy: ");
            player.PlayerInfo();
        }
        else
        {
            Console.WriteLine("Nie znaleziono zawodnika na podanej pozycji.");
        }
    }
}
 