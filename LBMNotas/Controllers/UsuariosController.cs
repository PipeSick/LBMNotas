using LBMNotas.Context;
using LBMNotas.Models;
using LBMNotas.Servicios;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Security.Claims;
using X.PagedList.Mvc;
using X.PagedList.Mvc.Core;
using X.PagedList;



namespace LBMNotas.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ApplicationDbContext context;
        public UsuariosController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }



        [AllowAnonymous]
        public IActionResult Registro()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Registro(RegistroViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }
            var usuario = new IdentityUser() { Email = modelo.Email, UserName = modelo.Nombre };
            await userManager.AddToRoleAsync(usuario, modelo.Rol);
            var resultado = await userManager.CreateAsync(usuario, password: modelo.Password);

            if (resultado.Succeeded)
            {
                return RedirectToAction("Listado", "Usuarios");
            }
            else
            {
                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(modelo);
            }
        }

        [AllowAnonymous]
        public IActionResult Login(string mensaje = null)
        {
            if (mensaje is not null)
            {
                ViewData["mensaje"] = mensaje;
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);

            }

            var usuario = context.Users.FirstOrDefault(u => u.Email == modelo.Email);

            var resultado = await signInManager.PasswordSignInAsync(usuario, modelo.Password, modelo.RememberMe, lockoutOnFailure: false);
            // Si las credenciales son correctas, se va al home.
            if (resultado.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            //si no devuelve error.
            else
            {
                ModelState.AddModelError(string.Empty, "Correo o contraseña Incorrectos.");
                return View(modelo);
            }   

                
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public ChallengeResult LoginExterno(string proveedor, string urlRetorno = null)
        {
            var urlRedireccion = Url.Action("RegistrarUsuarioExterno", values: new { urlRetorno });
            var propiedades = signInManager.ConfigureExternalAuthenticationProperties(proveedor, urlRedireccion);
            return new ChallengeResult(proveedor, propiedades);
        }

        [AllowAnonymous]
        public async Task<IActionResult> RegistrarUsuarioExterno(string urlRetorno = null, string remoteError = null)
        {
            urlRetorno = urlRetorno ?? Url.Content("~/");
            var mensaje = "";
            if (remoteError is not null)
            {
                mensaje = $"Error del proveedor externo: {remoteError}";
                return RedirectToAction("login", routeValues: new { mensaje });
            }
            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info is null)
            {
                mensaje = $"Error cargando la data de login externo";
                return RedirectToAction("login", routeValues: new { mensaje });
            }
            var resultadoLoginExterno = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey
                , isPersistent: true, bypassTwoFactor: true);
            var user = await userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            if (!user.LockoutEnabled)
            {
                mensaje = $"Error, el usuario se encuentra inactivo, por favor contacta al administrador.";
                return RedirectToAction("login", routeValues: new { mensaje });
            }
            if (resultadoLoginExterno.Succeeded)
            {
                return LocalRedirect(urlRetorno);
            }

            string email = "";
            if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
            {
                email = info.Principal.FindFirstValue(ClaimTypes.Email);
            }
            else
            {
                mensaje = "Error leyendo el email del usuario del proveedor";
                return RedirectToAction("login", routeValues: new { mensaje });

            }
            string name = "";
            string nombresinespacios = "";
            if (info.Principal.HasClaim(n => n.Type == ClaimTypes.Name))
            {
                name = info.Principal.FindFirstValue(ClaimTypes.Name);
            }
            nombresinespacios = name.Replace(" ", "");

            var usuario = new IdentityUser { Email = email, UserName = nombresinespacios };
            var resultadoCrearUsuario = await userManager.CreateAsync(usuario);
            if (!resultadoCrearUsuario.Succeeded)
            {
                mensaje = resultadoCrearUsuario.Errors.First().Description;
                return RedirectToAction("login", routeValues: new { mensaje });
            }

            var resultadoAgregarLogin = await userManager.AddLoginAsync(usuario, info);
            if (resultadoAgregarLogin.Succeeded)
            {
                await signInManager.SignInAsync(usuario, isPersistent: true, info.LoginProvider);
                return LocalRedirect(urlRetorno);
            }

            mensaje = "Ha Ocurrido un error agregando el login";
            return RedirectToAction("login", routeValues: new { mensaje });
        }

        [HttpPost]
        public IActionResult EditarUserView(string UserId)
        {
            var U = context.Users.Where(u => u.Id.Equals(UserId)).FirstOrDefault();
            var resultado = new UsuariosViewModel
            {
                IdUsuario = U.Id,
                NombreUsuario = U.UserName,
                Email = U.Email,
                Estado = U.LockoutEnabled,
                Contraseña = U.PasswordHash,
            };
            return View(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> EditarUser(UsuariosViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(usuario.IdUsuario);
                var currentRoles = await userManager.GetRolesAsync(user);
                string rolnuevo = usuario.Roles.FirstOrDefault();
                await userManager.RemoveFromRolesAsync(user, currentRoles); //Eliminar del antiguo rol.
                await userManager.AddToRoleAsync(user, rolnuevo); //Agregar al nuevo rol.
                var token = await userManager.GeneratePasswordResetTokenAsync(user); //generamos un token para actualizar contraseña
                var resultpassword = await userManager.ResetPasswordAsync(user, token, usuario.Contraseña); //se actualiza la contraseña mediante el token
                user.UserName = usuario.NombreUsuario;
                user.Email = usuario.Email;
                var resultuser = await userManager.UpdateAsync(user);
                return RedirectToAction("Listado", routeValues: new { mensaje = "El usuario " + usuario.Email + " se ha actualizado correctamente." });
            }
            else
            {
                return View(usuario);
                
            }
        }
    




        [HttpGet]
        [Authorize(Roles = Constantes.RolAdmin)] //*** Solo visible para Administradores
        public async Task<IActionResult> Listado(string mensaje = null, int pagina = 1)
        {
            {
                int pageSize = 5; // Número de elementos por página
                var roles = await context.Roles.ToListAsync();
                var usuarios = await context.Users
                    .OrderByDescending(x => x.LockoutEnabled)
                    .Skip((pagina -1 )* pageSize)
                    .Take(pageSize)
                    .GroupJoin(context.UserRoles,
                    user => user.Id,
                    userRoles => userRoles.UserId,
                    (user, userRoles) => new { User = user, UserRoles = userRoles })                   
                    .ToListAsync();
                var totalregistros = context.Users.Count();

                var resultado = new List<UsuariosViewModel>();

                foreach (var usuario in usuarios)
                {
                    var rolesDelUsuario = new List<IdentityRole<string>>();
                    foreach (var rol in usuario.UserRoles)
                    {
                        rolesDelUsuario.Add(new IdentityRole<string>
                        {
                            Id = rol.RoleId,
                            Name = roles.Where(x => x.Id == rol.RoleId).Select(x => x.Name).First()
                        });
                    }

                    resultado.Add(new UsuariosViewModel
                    {
                        IdUsuario = usuario.User.Id,
                        Email = usuario.User.Email,
                        NombreUsuario = usuario.User.UserName,
                        Estado = usuario.User.LockoutEnabled,
                        Roles = rolesDelUsuario.Select(x => x.Name).ToList()
                    });
                }

                var modelo = new UsuariosListadoViewModel();
                modelo.PaginaActual = pagina;
                modelo.RegistrosPorPagina = pageSize;
                modelo.TotalRegistros = totalregistros;
                modelo.Usuarios = resultado;  
                modelo.Mensaje = mensaje;
                return View(modelo);
            }

        }
        [HttpPost]
        [Authorize(Roles = Constantes.RolAdmin)] //*** Solo visible para Administradores
        public async Task<IActionResult> SuspenderUsuario(string email)
            {
                var usuario = await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
                if (usuario is null)
                {
                    return NotFound();
                }
                usuario.LockoutEnabled = false;
                var resultado = await userManager.UpdateAsync(usuario);
                if (resultado.Succeeded) {
                    return RedirectToAction("Listado", routeValues: new { mensaje = "El usuario " + email + " se ha inhabilitado correctamente" });
                }
                else
                {
                    return RedirectToAction("Listado", routeValues: new { mensaje = "Error Inhabilitando el usuario: " + email });
                }

            }
        [HttpPost]
        [Authorize(Roles = Constantes.RolAdmin)] //*** Solo visible para Administradores
        public async Task<IActionResult> HabilitarUsuario(string email)
        {
            var usuario = await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            if (usuario is null)
            {
                return NotFound();
            }
            usuario.LockoutEnabled = true;
            var resultado = await userManager.UpdateAsync(usuario);
            if (resultado.Succeeded)
            {
                return RedirectToAction("Listado", routeValues: new { mensaje = "El usuario " + email + " se ha habilitado correctamente" });
            }
            else
            {
                return RedirectToAction("Listado", routeValues: new { mensaje = "Ha ocurrido un error en la habilitación del usuario " + email });
            }

        }

        [HttpPost]
        [Authorize(Roles = Constantes.RolAdmin)] //*** Solo visible para Administradores
        public async Task<IActionResult> HacerAdmin(string email)
        {
            var usuario = await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            if (usuario is null)
                {
                    return NotFound();
                }

                await userManager.AddToRoleAsync(usuario, Constantes.RolAdmin);
                return RedirectToAction("Listado", routeValues: new { mensaje = "El usuario " + email + " se ha asignado como administrador correctamente" });

            }

        [HttpPost]
        [Authorize(Roles = Constantes.RolAdmin)] //*** Solo visible para Administradores
        public async Task<IActionResult> RemoverAdmin(string email)
        {
            var usuario = await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            if (usuario is null)
            {
                return NotFound();
            }

            await userManager.RemoveFromRoleAsync(usuario, Constantes.RolAdmin);
            return RedirectToAction("Listado", routeValues: new { mensaje = "El usuario " + email + " se le ha revocado el rol de administrador correctamente" });

            
        }


        






    }
}

