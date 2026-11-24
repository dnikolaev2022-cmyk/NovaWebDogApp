using WebDogApp.Core.Contracts;
using WebDogApp.Infrastructure.Data;
using WebDogApp.Infrastructure.Data.Domain;

public class BreedService : IBreedService
{
    private readonly ApplicationDbContext _context;

    public BreedService(ApplicationDbContext context)
    {
        _context = context;
    }

    public Breed GetBreedById(int breedId)
    {
        return _context.Breeds.Find(breedId);
    }

    public List<Breed> GetBreeds()
    {
        return _context.Breeds.ToList();
    }

    public List<Dog> GetDogsByBreed(int breedId)
    {
        return _context.Dogs
            .Where(x => x.BreedId == breedId)
            .ToList();
    }

    public bool Create(string name)
    {
        Breed item = new Breed
        {
            Name = name
        };

        _context.Breeds.Add(item);

        return _context.SaveChanges() != 0;
    }

    public bool UpdateBreed(int breedId, string name)
    {
        Breed breed = _context.Breeds.Find(breedId);

        if (breed == null)
        {
            return false;
        }

        breed.Name = name;

        _context.Breeds.Update(breed);

        return _context.SaveChanges() != 0;
    }

    public bool RemoveById(int breedId)
    {
        Breed breed = _context.Breeds.Find(breedId);

        if (breed == null)
        {
            return false;
        }

        if (_context.Dogs.Any(d => d.BreedId == breedId))
        {
            return false;
        }

        _context.Breeds.Remove(breed);

        return _context.SaveChanges() != 0;
    }
}