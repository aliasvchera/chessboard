using Microsoft.AspNetCore.Identity;

namespace ChessBoard.Models
{
    public class User : IdentityUser
    {
        public string Language { get; set; }
    }
}
