public class DVD : BorrowableContent
{
    public DVD() : base()
    {

    }
    public override void Open()
    {
        TerminalUI.StringPressToContinue("needs functionality");
    }
}