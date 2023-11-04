using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    void AddMemoryList(T inMemory);
}