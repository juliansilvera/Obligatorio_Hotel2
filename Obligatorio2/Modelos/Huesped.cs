using System.ComponentModel.DataAnnotations;

public class Huesped
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Apellido { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [MaxLength(255)]
    public string Contraseña { get; set; } = null!;

    public Huesped() { }

    public Huesped(int id, string nombre, string apellido, string email, string contraseña)
    {
        Id = id;
        Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
        Apellido = apellido ?? throw new ArgumentNullException(nameof(apellido));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Contraseña = contraseña ?? throw new ArgumentNullException(nameof(contraseña));
    }
}
