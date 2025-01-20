using System;
using System.Collections.Generic;
using System.IO;

using DataBase.Exceptions;

namespace DataBase;

public class DBFile<T>
    where T : DataBaseObject, new()
{
    protected string basePath;

    protected DBFile(string basePath)
        => this.basePath = basePath;

    public string DBPath {
        get
        {
            var filename = typeof(T).Name;
            var path = this.basePath + filename + ".csv";
            return path;
        }
    }

    protected List<string> openFile()
    {
        List<string> lines = new();
        StreamReader reader = null;
        var path = this.DBPath;

        if(!File.Exists(path))
            File.Create(path).Close();

        try
        {
            reader = new StreamReader(path);
            while (!reader.EndOfStream)
                lines.Add(reader.ReadLine());
        } 
        catch 
        {
            lines = null;
        }
        finally
        {
            reader?.Close();
        }

        return lines;
    }

    protected bool saveFile(List<string> lines)
    {
        StreamWriter writer = null;
        bool succes = true;
        var path = this.DBPath;

        if(!File.Exists(path))
            File.Create(path).Close();

        try
        {
            writer = new StreamWriter(path);
            for (int i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                writer.WriteLine(line);
            }
        }
        catch
        {
            succes = false;
        }
        finally
        {
            writer.Close();
        }

        return succes;
    }

    public List<T> All
    {
        get
        {
            var lines = openFile();
            if(lines is null)
                throw new DataCannotBeOpenedException(this.DBPath);

            var all = new List<T>();

            try
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    var line = lines[i];
                    var obj = new T();
                    var data = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    obj.LoadFrom(data);
                    all.Add(obj);
                }
            }
            catch
            {
                throw new ConvertObjectException();
            }
            return all;
        }
    }

    public void Save (List<T> all)
    {
        List<string> lines = new();
        for (int i = 0; i < all.Count; i++)
        {
            string[] data = all[i].SaveTo();
            string line = string.Empty;

            for (int j = 0; j < data.Length; j++)
                line += data[j] + ",";
            
            lines.Add(line);
        }

        if(saveFile(lines))
            return;
        
        throw new DataCannotBeOpenedException(this.DBPath);
    }

    protected static DBFile<T> temp = null;
    public static DBFile<T> Temp
    {
        get
        {
            if(temp == null)
                temp = new DBFile<T>(Path.GetTempPath());
            return temp;
        }
    }

    protected static DBFile<T> app = null;
    public static DBFile<T> App
    {
        get
        {
            if(app == null)
                app = new DBFile<T>("");
            return app;
        }
    }

    protected static DBFile<T> custom = null;
    public static DBFile<T> Custom
    {
        get
        {
            if(custom == null)
                throw new CustomNotDefinedException();
            return custom;
        }
    }

    public static void SetCustom(string path)
        => custom = new DBFile<T>(path);


}