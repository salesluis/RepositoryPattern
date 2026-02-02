using Microsoft.EntityFrameworkCore;

namespace RepositoryStore.Entities;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

   
}