using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineLearningWebAPI.Configurations;
using OnlineLearningWebAPI.DTOs.request.AccountRequest;
using OnlineLearningWebAPI.Models;

namespace OnlineLearningWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // DI
        private readonly UserManager<Account> _userManager;
        private readonly JwtConfig _jwtConfig;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AuthController> _logger;


        public AuthController(UserManager<Account> userManager,
            IOptions<JwtConfig> jwtConfig,
            TokenValidationParameters tokenValidationParameters,
            RoleManager<IdentityRole> roleManager,
            ILogger<AuthController> logger)
        {
            _userManager = userManager;
            _jwtConfig = jwtConfig.Value;
            _tokenValidationParameters = tokenValidationParameters;
            _roleManager = roleManager;
            _logger = logger;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Error = "Invalid data" });
            }

            // Kiểm tra người dùng có tồn tại không
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginRequest.Password))
            {
                return Unauthorized(new { Error = "Invalid credentials" });
            }

            // Tạo token
            var token = GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var account = new Account
            {
                Email = request.Email,
                UserName = request.Email,
                Avatar = null,
                IsBan = false,
                IsVip = false
            };

            // Tạo tài khoản
            var result = await _userManager.CreateAsync(account, request.Password);

            if (result.Succeeded)
            {
                // Gán Role dựa theo thông tin từ request.Role
                if (!string.IsNullOrEmpty(request.Role))
                {
                    var roleExists = await _roleManager.RoleExistsAsync(request.Role);

                    if (roleExists)
                    {
                        var roleResult = await _userManager.AddToRoleAsync(account, request.Role);

                        if (!roleResult.Succeeded)
                        {
                            return BadRequest(new { message = "Failed to assign role" });
                        }
                    }
                    else
                    {
                        return BadRequest(new { message = "Role không tồn tại" });
                    }
                }

                return Ok(new { message = "Đăng ký thành công" });
            }

            return BadRequest(result.Errors);
        }

        private async Task<string> GenerateJwtToken(Account user)
        {
            // Lấy key mã hóa từ JwtConfig
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret ?? string.Empty);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Unique token ID
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            // Lấy danh sách roles của user từ database
            var roles = await _userManager.GetRolesAsync(user);

            // Thêm roles vào JWT claims payload
            foreach (var role in roles)
            {
                _logger.LogInformation("Adding role '{Role}' to JWT claims", role);
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }


    }
}
