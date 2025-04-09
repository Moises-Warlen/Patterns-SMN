using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Patterns.Models;
using Patterns.db_context;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System;

namespace Patterns.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Context _context;

        public UsuarioController(Context context)
        {
            _context = context;
        }

        // GET: /Usuario
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Lista separada
        public async Task<IActionResult> GridUsuario()
        {
            var usuarios = await _context.Usuario.ToListAsync();
            return View(usuarios);
        }

        // GET: Formulário de criação
        public IActionResult Create()
        {
            return View("AdicionarUsuario");
        }

        // POST: Criar usuário
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View("AdicionarUsuario", usuario);
            }

            if (string.IsNullOrWhiteSpace(usuario.Senha))
            {
                ModelState.AddModelError("Senha", "A senha é obrigatória.");
                return View("AdicionarUsuario", usuario);
            }

            // Criptografar a senha antes de salvar
            usuario.Senha = GerarHash(usuario.Senha);

            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Editar usuário
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null) return NotFound();

            return View("EditarUsuario", usuario);
        }

        // POST: Salvar edição
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario usuario)
        {
            if (id != usuario.cod_usuario) return NotFound();

            if (!ModelState.IsValid)
            {
                return View("EditarUsuario", usuario);
            }

            try
            {
                var usuarioBanco = await _context.Usuario.AsNoTracking()
                    .FirstOrDefaultAsync(u => u.cod_usuario == id);

                // Se nova senha for informada, criptografa; senão, mantém a antiga
                if (!string.IsNullOrWhiteSpace(usuario.Senha))
                {
                    usuario.Senha = GerarHash(usuario.Senha);
                }
                else
                {
                    usuario.Senha = usuarioBanco?.Senha;
                }

                _context.Update(usuario);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Usuario.Any(e => e.cod_usuario == id))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // Criptografia SHA256
        private string GerarHash(string senha)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(senha);
                var hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}
