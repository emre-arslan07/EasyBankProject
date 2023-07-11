using Microsoft.AspNetCore.Identity;

namespace EasyBankProject.UI.Models
{
	public class CustomerIdentityValidator:IdentityErrorDescriber
	{
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = "PasswordTooShort",
				Description = $"Parola minimum {length} karakter olmalıdır."
			};
		}

		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresUpper",
				Description = $"Parola minimum 1 büyük harf içermelidir."
			};
		}

		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresUpper",
				Description = $"Parola minimum 1 küçük harf içermelidir."
			};
		}

		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresNonAlphaNumeric",
				Description = $"Parola en az 1 sembol içermelidir."
			};
		}



		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresDigit",
				Description = $"Parola en az 1 rakam içermelidir ('0'.'9')."
			};
		}
	}
}
