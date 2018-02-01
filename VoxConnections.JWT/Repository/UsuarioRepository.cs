using VoxConnections.JWT.Context;
using VoxConnections.JWT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoxConnections.JWT.Repository
{
    public class UsuarioRepository
    {
        private readonly VoxContext _context;

        public UsuarioRepository(VoxContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Find(LoginModel loginModel)
        {


            var result = await _context.Usuario
                .Where(e => e.Senha.Equals(loginModel.Password) &&
                            e.Email.Equals(loginModel.Username) &&
                            e.Cadastrado == true)
                .FirstOrDefaultAsync();


            return result;
        }

        public async Task<int> FindCandidato(Guid idUsuario)
        {


            var result = await _context.Candidato
                .Where(e => e.IdUsuario.Equals(idUsuario))
                .Select(c => c.IdCandidato)
                .FirstOrDefaultAsync();


            return result;
        }

        public async Task<int> FindGestor(Guid idUsuario)
        {


            var result = await _context.Gestor
                .Where(e => e.IdUsuario.Equals(idUsuario))
                .Select(c => c.IdGestor)
                .FirstOrDefaultAsync();


            return result;
        }

        public async Task<int> FindHead(Guid idUsuario)
        {


            var result = await _context.Headhunter
                .Where(e => e.IdUsuario.Equals(idUsuario))
                .Select(c => c.IdHeadhunter)
                .FirstOrDefaultAsync();


            return result;
        }
    }
}
