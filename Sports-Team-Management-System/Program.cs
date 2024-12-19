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

    public Player(string name, string position, int score)
    {
        Name = name;
        Position = position;
        Score = score;

    }

    public static void ScoreUpdate(List<Player> players)
    {
        Console.WriteLine("Podaj nazwe zawodnika, dla którego chcesz zaktualizować wynik: ");
        string wybor = Console.ReadLine();
        
        
        Console.WriteLine("Podaj wynik: "); 
        int wynik = int.Parse(Console.ReadLine());
        
        Player? player = players.Find(x => x.Name == wybor);

        if (player != null)
        {
            player.Score = wynik;
            Console.WriteLine($"Wynik zawodnika {player.Name} zaktualizowany na {player.Score}");
        }
        else
        {
            Console.WriteLine("zawodnik nie znaleziony");
        }
    }
    
    public void PlayerInfo()
    {
        Console.WriteLine($"Zawodnik: {Name}, Pozycja: {Position}, Punkty: {Score}");
    }
    
    public static List<Player> SzukajZawodnika(List<Player> players, string position)
    {
       return players.Where(x => x.Position == position).ToList();
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
            
            Console.WriteLine("Podaj poczatkowy wynik zawodnika: ");
            int wynik = int.Parse(Console.ReadLine());
            
            Players.Add(new Player(nazwa, pozycja, wynik)); //dodano wynik
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

    public int SumaPkt()
    {
        return Players.Sum(p => p.Score);
    }
    public void StatystykiDruzyny()
    {
        Console.WriteLine($"Punkty zdobyte przez druzyne: {SumaPkt()} ");
       
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
        
        
        Console.WriteLine("Aktualizuj wynik zawodnika");
        var players1 = team.Players.Cast<Player>().ToList(); // Cast - konwersja do List<Player>
        Player.ScoreUpdate(players1);
        
        team.Usun();
        
        var playersList = team.Players.Cast<IPlayer>().ToList();
        double sredniaPunktow = Team.SredniaPkt(playersList);
        Console.WriteLine($"Średnia punktów drużyny: {sredniaPunktow}");
        
        
        
        
        Console.WriteLine("Podaj z jakiej pozycji mają być zawodnicy:");
        string pozycja = Console.ReadLine();

        Console.WriteLine($"Zawodnicy na pozycji {pozycja}:");
        var znalezieniZawodnicy = Player.SzukajZawodnika(players1, pozycja);

        if (znalezieniZawodnicy.Any())
        {
            foreach (var player in znalezieniZawodnicy)
            {
                player.PlayerInfo();
            }
        }
        else
        {
            Console.WriteLine($"Nie znaleziono zawodników na pozycji {pozycja}.");
        }
        
        
        
        
        Console.WriteLine("Sprawdz statystyki druzyny: ");
        team.StatystykiDruzyny();
        
    }
}
 