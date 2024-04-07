public abstract class BorrowableContent : Content
{
    bool IsBorrowed { get; set; }
    bool IsRequested { get; set; }

    public BorrowableContent() : base()
    {

    }

    public bool CheckOut()
    {
        if (IsBorrowed)
        {
            return false;
        }
        else
        {
            if (IsLost)
            {
                return false;
            }
            else
            {
                IsBorrowed = true;
                return true;
            }
        }
    }
    public bool CanRenew(int timesRenewed)
    {
        if (IsRequested)
        {
            return false;
        }
        else if (timesRenewed >= 3)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}