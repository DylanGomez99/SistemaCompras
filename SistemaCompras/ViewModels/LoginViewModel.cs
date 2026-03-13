using System.ComponentModel.DataAnnotations;

namespace SistemaCompras.ViewModels
{
	public class LoginViewModel
	{
		[Required]
		[Display(Name = "Usuario")]
		public string UserName { get; set; } = string.Empty;

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Contraseña")]
		public string Password { get; set; } = string.Empty;
	}
}