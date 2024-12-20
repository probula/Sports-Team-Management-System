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
        if (players == null || !players.Any())
        {
            Console.WriteLine("Nie ma żadnych zawodników do zaktualizowania.");
            return;
        }
        Player player = null; // deklaracja zmiennej


        while (true)
        {
            Console.WriteLine("Podaj nazwe zawodnika, dla którego chcesz zaktualizować wynik: ");
            string wybor = Console.ReadLine()?.Trim();
            
            if (string.IsNullOrWhiteSpace(wybor))
            {
                Console.WriteLine("Nazwa zawodnika nie może być pusta!");
                continue;
            }
            

            player = players.Find(x => x.Name.Equals(wybor, StringComparison.OrdinalIgnoreCase));

            if (player == null)
            {
                Console.WriteLine($"Nie znaleziono zawodnika o nazwie {wybor}");
            }
            else
            {
                break; //koniec petli, zawodnik znaleziony
            }
        }
        Console.WriteLine("Znaleziono zawodnika!\nPodaj nowy wynik:");
        int wynik = int.Parse(Console.ReadLine());
        player.Score = wynik;
    }

    public void PlayerInfo()
    {
        Console.WriteLine($"Zawodnik: {Name}, Pozycja: {Position}, Punkty: {Score}");
    }
    
    public static List<Player> SzukajZawodnika(List<Player> players, string position)
    {
        position = position.ToLower().Trim();
       return players.Where(x => x.Position == position).ToList();
    }
    
}

class Team
{
    public List<IPlayer> Players = new List<IPlayer>();
    
    public void Dodaj()
    {
        Console.WriteLine("Ile zawodników chcesz dodać?: ");
        if (!int.TryParse(Console.ReadLine(), out int ilosc) || ilosc <= 0)
        {
            Console.WriteLine("Nieprawidłowa liczba!");
            return;
        }
        
        for (int i = 0; i < ilosc; i++)
        {
            
            Console.WriteLine("Podaj nazwe zawodnika");
            string nazwa = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nazwa))
            {
                Console.WriteLine("Nazwa zawodnika nie moze byc pusta!");
                i--;
                continue;
            }
            Console.WriteLine("Podaj pozycje zawodnika: ");
            string pozycja = Console.ReadLine().ToLower().Trim();
            if (string.IsNullOrWhiteSpace(pozycja))
            {
                Console.WriteLine("Pozycja nie moze byc pusta!");
                continue;
            }
            
            Console.WriteLine("Podaj poczatkowy wynik zawodnika: ");
            if (!int.TryParse(Console.ReadLine(), out int wynik) || wynik < 0)
            {
                Console.WriteLine("Nieprawidłowy wynik!");
                i--;
                continue;
            }
            Players.Add(new Player(nazwa, pozycja, wynik)); //dodano wynik
            Console.WriteLine($"Dodano zawodnika: {nazwa}, Pozycja: {pozycja}, Wynik: {wynik}");
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

    public static double SredniaPkt(List<Player> players)
    {
        
        return players.Average(x => x.Score);
    }
}
internal class Program
{
    public static void Main(string[] args)
    {
        Team team = new Team();
        var players1 = team.Players.Cast<Player>().ToList(); // Cast - konwersja do List<Player>

        while (true)
        {

            Console.WriteLine("dodaj zawodnika - 1 | usun zawodnika - 2 | zaktualizuj wynik - 3 | szukaj zawodnika - 4 | statystyki drużyny - 5 | średnia pkt - 6 | wyjście - 7");
            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    team.Dodaj();
                    break;
                case "2":
                    team.Usun();
                    break;
                case "3":
                    Console.WriteLine("Aktualizuj wynik zawodnika");
                    Player.ScoreUpdate(team.Players.Cast<Player>().ToList()); //przekazuje liste
                    break;
                case "4":
                    Console.WriteLine("Podaj z jakiej pozycji mają być zawodnicy:");
                    string pozycja = Console.ReadLine();
                    Console.WriteLine($"Zawodnicy na pozycji {pozycja}:");
                    var znalezieniZawodnicy = Player.SzukajZawodnika(team.Players.Cast<Player>().ToList(), pozycja);
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
                    break;
                    
                case "5":
                        Console.WriteLine("Sprawdz statystyki druzyny: ");
                        team.StatystykiDruzyny();
                        break;
                case "6":
                    var playersList = team.Players.Cast<Player>().ToList();
                    double sredniaPunktow = Team.SredniaPkt(playersList);
                    Console.WriteLine($"Średnia punktów drużyny: {sredniaPunktow}");
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowa opcja!");
                    break;
            }
        }
    }
}
 