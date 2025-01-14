using System.Collections.Generic;
using DataBase;
namespace Model;

public interface IRepository<T> where T : DataBaseObject  { // referenciando
    List<T> All {get;}
    void Add(T obj);

}
