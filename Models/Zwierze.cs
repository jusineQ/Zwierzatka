namespace Zwierzatka.Models;

public class Zwierze
{
    public int id { get; set; }
    public String imie { get; set; }
    public int wiek { get; set; }
    public String rasa { get; set; }
    public String zdjecie;
    public String notatki { get; set; }
    public int uzytkownikId { get; set; }
}