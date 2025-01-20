using System.Collections.Generic;
using DataBase;

namespace Model.Repository;

public class AlunoDBRepository : IRepository<Aluno> {

    protected DBSqlSrv<Aluno> db;

    [System.Obsolete]
    public AlunoDBRepository() {
        db = new DBSqlSrv<Aluno>(
        "CA-C-0064T\\SQLEXPRESS",
        "SistemaEscolar");
    }

    [System.Obsolete]
    public List<Aluno> All => db.All;

    [System.Obsolete]
    public void Add(Aluno obj)
    {
         db.Save(obj);
    }
};

