public class EuaDismissalProcess : DismissalProcess
{
    public override string Title => "Employe Dimissal";
    public override void Apply(DismissalArgs args)
    {
        args.Company.Money -= 4 * args.Employe.Wage;
    }
}
public class EuaWagePaymentProcess : WagePaymentProcess
{
    public override string Title => "Salary Payment";
    public override void Apply(WagePaymentArgs args)
    {
        args.Company.Money -= 1.65m * args.Employe.Wage + 1700;
    }
}
public class EuaContractProcess : ContractProcess
{
    public override string Title => "Contract Employees";
    public override void Apply(ContractArgs args)
    {
        args.Company.Money += 4 * args.Employe.Wage;
    }
}
public class EuaProcessFactory : IProcessFactory
{
    public ContractProcess CreateContractProcess()
        => new EuaContractProcess();
    public DismissalProcess CreateDismissalProcess()
        => new EuaDismissalProcess();
    public WagePaymentProcess CreateWagePaymentProcess()
        => new EuaWagePaymentProcess();
}