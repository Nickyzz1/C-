using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.Marshalling;
using DataBase.Exceptions;

namespace DataBase;
public class DB<T> where T : DataBaseObject, new() { // definiu o tipo genérico limitado a ser um dbo, quando criar uma mdoel precisa ser dese tipo, ou seja, é como uma interface, as classes que hewrdarem precisma implementar os métodos
    private string basePath; // onde vai salvar o arquivo
    private DB(string basePath) => this.basePath = basePath; // construtor privado que vai construir com base no path inserido, tem ou custom, ou app ou file, sempre receber um db de t

    public string DBPath { get { // personalizando o get
        var filename = typeof(T).Name; // databaseObject?
        var path = this.basePath + filename + ".csv" ; // extenssão do arquivo a retornar
        return path;
    }} // vai pegar o local do arquicvo a adc ao nome da entidade

    private List<string> openFile() { // vai ler o arquivo e ver se tem ou nn dados, se n tiver ele vai criar

        List<string> lines = new();
        StreamReader reader = null;
        var path = this.DBPath;
        if(!File.Exists(path)) { // se o arquiv nn existir criua ele no caminho especificado
            File.Create(path).Close();
        }

        try
        {
            reader =  new StreamReader(path);
            while (!reader.EndOfStream) { // enquanto nn estiver no final do arquivo
                lines.Add(reader.ReadLine()) ;
            }
        }
        catch 
        {
            lines = null;
        } finally {
            reader?.Close(); // pode ser nulo se nn for possível abrir ele 
        }

        return lines;
    }

    private bool saveFile(List<string> lines) { // salvar arquivo
        StreamWriter writer = null; // cria um escritor
        bool sucess = true;
        var path = this.DBPath; // pega o path onde o arquivo está

        if(!File.Exists(path)) { // se o arquivo procurado nn existir
            File.Create(path).Close();
        }
        try {
        
            writer = new StreamWriter(path); // o escritor vaui escreverno arquivo no caminho
            for(int i = 0; i < lines.Count; i++) {
                var line = lines[i]; // passando pelas linhas
                writer.WriteLine(line); //ele vai escrever a linha

            }

        }
        catch 
        {
            sucess = false;
        
        } finally {
            writer?.Close();
        }

        return sucess;
    }

    public List<T> All { // vai retornar todos os items de qualquer documento lido
        get {
            var lines = openFile(); // lendo o arquivo inteiro
            if(lines is null)
                throw new DataCannotBeOpenedExecption(this.DBPath);

            var all = new List<T>();

            try
            {
                for(int i = 0; i < lines.Count; i ++) {
                    var line = lines[i];
                    var obj = new T();
                    var data = line.Split(',', StringSplitOptions.RemoveEmptyEntries); // temnos um csv ele vai fazer uma lista de string, ass lista vaui se ruma coluna inteira
                    obj.LoadFrom(data);
                    all.Add(obj);
                
                } 
            }
            catch (System.Exception)
            {
                
                throw new ConvertObjectExecption();
            }
            finally {}

            return all;
        }
        
    }

    public void save(List<T> all) {
        List<string> lines = new(); // lista de linhas
        for(int i = 0; i < all.Count; i++) { // todas as linhas, está pasando por cada uma
            var data = all[i].SaveTo(); // converte todos os atributos numa lista de string
            string line = string.Empty; // cria uma string vazia

            for(int j = 0; j < data.Length; j++) {
                line += data[j] + ","; // faz as informações se separarem por virgula
            }
            lines.Add(line);
        }

        if (saveFile(lines)) {return;} 

        throw new DataCannotBeOpenedExecption(this.DBPath);
    }

    // formas de criarum banco de dados
    // só pode ter um de cada no programa, um custom, um temp e um app

    private static DB<T> temp = null; // banco temporário, o verddadeirto banco
    public static DB<T> Temp { // atributo publico que seta o valor privado
        get {
            if (temp == null)    {
                temp = new DB<T>(Path.GetTempPath());
            }
            return temp;
        }
    }

    private static DB<T> app = null; // banco app, base na pasta default do executavel
    public static DB<T> App {
        get {
            if(app == null){
                app = new DB<T>(""); // criou um path vazio
            }
            return app;
        }
    }

    private static DB<T> custom = null;  // banco customizado

    public static DB<T> Custom {
        get {
            if (custom == null){throw new CustomNotDefinedExecption();}
            return custom;
        }
    }

    public static void SetCustom(string path) => custom = new DB<T>(path);
}