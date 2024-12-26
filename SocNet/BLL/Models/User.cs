using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocNet.BLL.Models;

internal class User
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

    public User(
        int id, string firstName, string lastName, string password,
        string email, string photo, string favMovie, string favBook, 
        IEnumerable<Message> incomingMessages, IEnumerable<Message> outgoingMessages)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Password = password;
        this.Email = email;
        this.Photo = photo;
        this.FavoriteMovie = favMovie;
        this.FavoriteBook = favBook;
        this.incomingMessages = incomingMessages;
        this.outgoingMessages = outgoingMessages;
    }
}
