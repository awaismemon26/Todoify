using System;

namespace TodoifyUI.Library.Models
{
    public interface ILoggedInUserModel
    {
        string Id { get; set; }
        string Email { get; set; }
        string Token { get; set; }
    }
}