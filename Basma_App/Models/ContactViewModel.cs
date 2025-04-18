  // Models/ContactViewModel.cs
    using System.ComponentModel.DataAnnotations;

public class ContactViewModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MaxLength(250, ErrorMessage = "Message cannot be more than 250 characters.")]
    public string Message { get; set; }
}
