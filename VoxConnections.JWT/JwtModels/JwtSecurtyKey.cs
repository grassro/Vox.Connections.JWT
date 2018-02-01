using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace VoxConnections.JWT.JwtModels
{
    public static class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string secret) => 
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
    }
}