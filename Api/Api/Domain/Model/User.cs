using Api.Domain.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Model
{
    public class User : BaseTable
    {
        public virtual int Id { get; protected set; }

        public virtual string Name { get; set; }

        [Required]
        public virtual string CNPJ { get; set; }

        [Required, EmailAddress]
        public virtual string Email { get; set; }

        [Required]
        public virtual string Password { get; set; }
    }
}