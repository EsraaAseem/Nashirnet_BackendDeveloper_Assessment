using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.IServices;
using ProductManagement.Application.Models.AuthModels;
using ProductManagement.Domain.Enums;

namespace ProductManagement.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var roles = await _authService.GetAllRoles();

            ViewBag.Roles = roles.Data;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterRequest vm)
        {
            if (!ModelState.IsValid)
            {
                var roles = await _authService.GetAllRoles();

                ViewBag.Roles = roles.Data;
                return View(vm);

            }

            var request = new RegisterRequest
            {
                Name = vm.Name,
                Email = vm.Email,
                Password = vm.Password,
                RoleId=vm.RoleId
            };

            var result = await _authService.RegisterAsync(request);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                var roles = await _authService.GetAllRoles();
                ViewBag.Roles = roles.Data;
                return View(vm);


            }

            TempData["SuccessMessage"] = result.Message;
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequest request, string? returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (!ModelState.IsValid)
                return View(request);

            var result = await _authService.LoginAsync(request);

            if (!result.IsSuccess || result.Data is null)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(request);
            }

            Response.Cookies.Append("access_token", result.Data.AccessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddDays(1)
            });

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Product");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("access_token");
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult AccessDenied() => View();
    }
}