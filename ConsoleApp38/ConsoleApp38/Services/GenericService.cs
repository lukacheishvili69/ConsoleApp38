using ConsoleApp38.Interfaces;
using System.ComponentModel.Design;
using System.Text.Json;

namespace ConsoleApp38.Services;

public class GenericService<T> : IGenericServices<T> where T : class
{
    protected List<T> _collection;
    private readonly String filePath;
    public GenericService(string filePath)
    {
        _collection = new List<T>();
        this.filePath = filePath;
        ReadFromFile();
    }
    public bool Addnew(T req)
    {
        var exist = _collection.Exists(i => i == req);
        if (exist) throw new ArgumentException("Msgavsi chanaweri ukve arsebobs");
       else
        {
            
            _collection.Add(req);
            SaveChangesToFile();
            return true;
        }
        
    }

    public bool Delete(T entity)
    {
        var exist = _collection.Exists(i => i == entity);
        if (exist) throw new ArgumentException("Msgavsi chanaweri ar arsebobs");
        else
        {
            _collection.Remove(entity);
            SaveChangesToFile();
            return true;
        }
        
    }

    public List<T> Getall()
    {
        return _collection;
    }


    public void UpdateAt(int index, T entity)
    {
        if (index >= 0 && index < _collection.Count)
        {
            _collection[index] = entity;
        }
    }
    private void SaveChangesToFile()
    {
        var Serialized = JsonSerializer.Serialize<List<T>>(_collection);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            File.Create(filePath).Close();
            File.WriteAllText(filePath, Serialized);
        }
        else
        {
            File.Create(filePath).Close();
            File.WriteAllText(filePath, Serialized);
        }
    }

    private void ReadFromFile()
    {
        if (File.Exists(filePath))
        {
            var Alltext = File.ReadAllText(filePath);
            var Deserialize = JsonSerializer.Deserialize<List<T>>(Alltext);
            if (Deserialize != null)
            {
                _collection = Deserialize;
            }
        }
    }
}
