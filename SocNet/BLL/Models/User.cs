namespace SocNet.BLL.Models;

/// <summary>
/// Описание  объекта Пользователь, которой оперирует приложение внутри себя
/// </summary>
public class User
{
    public int Id { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password {  get; set; }
    public string Email { get; set; }
    public string Photo { get; set; }
    public string FavoriteMovie { get; set; }
    public string FavoriteBook { get; set;}
    public IEnumerable<Message> incomingMessages;
    public IEnumerable<Message> outgoingMessages;
    public IEnumerable<Friend> friends;

    public User(
        int id, string firstName, string lastName, string password,
        string email, string photo, string favMovie, string favBook, 
        IEnumerable<Message> incomingMessages, IEnumerable<Message> outgoingMessages, IEnumerable<Friend> friends)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        Email = email;
        Photo = photo;
        FavoriteMovie = favMovie;
        FavoriteBook = favBook;
        this.incomingMessages = incomingMessages;
        this.outgoingMessages = outgoingMessages;
        this.friends = friends;
    }
}
