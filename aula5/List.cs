using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;
namespace lista;

public class myList<T>(){

    public int Size{get;set;} = 2;

    public T[] Array{get;set;} = new T[2];

    public int Count{get;set;} = 1;

  
    public T this[int index] {
        get { return Array[index];}
        set {Array[index] = value;}
    }

    public void Add(T value) {
        if(Count == Size) {

            T[] newArray = new T[Size + 2];

            for(int i = 0; i < Array.Length; i ++) {
                newArray[i] = Array[i];
            }

            this.Array = newArray;
            Size+=2;
            Array[Count - 1] = value;
            Count++;

        } else {
            Array[Count - 1] = value;
            Count++;
        }
    }

}

