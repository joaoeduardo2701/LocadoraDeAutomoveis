using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LocadoraDeAutomoveis.WebApp.Models
{
    public class FormularioAutomovelViewModel
    {
        [Required(ErrorMessage = "O modelo é obrigatório")]
        [MinLength(3, ErrorMessage = "O modelo deve conter ao menos 3 caracteres")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "A marca é obrigatória")]
        [MinLength(2, ErrorMessage = "A marca deve conter ao menos 2 caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O tipo de combustível é obrigatório")]
        public int TipoCombustivel { get; set; }

        [Required(ErrorMessage = "A capacidade do tanque é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "A capacidade do tanque deve ser maior que 0")]
        public int CapacidadeTanque { get; set; }

        [Required(ErrorMessage = "O grupo de automóveis é obrigatório")]
        public int GrupoAutomoveisId { get; set; }

        public IEnumerable<SelectListItem>? GruposAutomoveis { get; set; }
    }

    public class InserirAutomovelViewModel : FormularioAutomovelViewModel { }

    public class EditarAutomovelViewModel : FormularioAutomovelViewModel
    {
        public int Id { get; set; }
    }

    public class ListarAutomovelViewModel
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string TipoCombustivel { get; set; }
        public int CapacidadeTanque { get; set; }
        public string GrupoAutomoveis { get; set; }
    }

    public class DetalhesAutomovelViewModel
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string TipoCombustivel { get; set; }
        public int CapacidadeTanque { get; set; }
        public string GrupoAutomoveis { get; set; }
    }
}
