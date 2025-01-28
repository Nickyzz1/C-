public class ArgentinaDismissalProcess : DismissalProcess
{
    public override string Title => "Despido de Empleados"; // titulo do processo
    public override void Apply(DismissalArgs args) // aplicando personalização, ar: compania e empregado
    {
        args.Company.Money -= 3 * args.Employe.Wage;
    }
}
public class ArgentinaWagePaymentProcess : WagePaymentProcess
{
    public override string Title => "Pago de salario";
    public override void Apply(WagePaymentArgs args)
    {
        args.Company.Money -= 1.65m * args.Employe.Wage + 700;
    }
}
public class ArgentinaContractProcess : ContractProcess
{
    public override string Title => "Contratacion Empleados";
    public override void Apply(ContractArgs args)
    {
        args.Company.Money += 3 * args.Employe.Wage;
    }
}
public class ArgentinaProcessFactory : IProcessFactory // retorna novas instancias
{
    public ContractProcess CreateContractProcess()
        => new ArgentinaContractProcess();
    public DismissalProcess CreateDismissalProcess()
        => new ArgentinaDismissalProcess();
    public WagePaymentProcess CreateWagePaymentProcess()
        => new ArgentinaWagePaymentProcess();
}