

using System.ComponentModel;

namespace ConsoleApp38.Interfaces;

public interface IGenericServices<T>where T: class
{
    bool Addnew(T req);
    List<T> Getall();
    bool Delete(T entity);
    void UpdateAt(int index, T entity);

}
