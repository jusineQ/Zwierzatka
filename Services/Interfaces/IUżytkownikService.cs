namespace Zwierzatka.Services.Interfaces
{
    public interface IUżytkownikService
    {
        Task<int> Zawiera(string imie, string haslo);

    }
}
