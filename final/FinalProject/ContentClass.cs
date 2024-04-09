using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;
public abstract class Content
{
    [Key]
    public int ContentID { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    [NotNull]
    public bool IsLost { get; set; }
    

    public Content()
    {

    }
    public abstract void BorrowedMain(User user);
    public abstract void SearchedMain(User user);
    public abstract void Open();
    public override string ToString()
    {
        return $"{Title}, {ContentID}.";
    }
}