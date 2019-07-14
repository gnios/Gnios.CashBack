using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gnios.CashBack.Api.GenericControllers
{
    public class Entidade
    {
        [Column("id")]
        [Key]
        [DatabaseGenerat‌ed(DatabaseGeneratedOp‌​tion.Identity)]
        public int Id { get; set; }
    }

}
