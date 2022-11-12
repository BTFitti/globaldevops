using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Models
{
    [Table("tblRadar")]
    public class Radar
    {
        [Column("Nome")]
        [Display(Name = "NomeAvenida")]
        public string NomeAvenida { get; set; }

        [Column("Cidade")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Column("ID")]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Column("Km")]
        [Display(Name = "Km")]
        public string Km { get; set; }

    }

    public enum Radares
    {
        sim, nao
    }

    public enum Ativo
    {
        sim, nao
    }
}
