using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ef_api5.Models;

public class Categoria
{
    [Key]
    public Guid CategoriaID {get;set;}
    [Required]
    [MaxLength(150)]
    public string Nombre {get;set;}
    public string Descripcion {get;set;}
    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas {get;set;}
}