using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public abstract class Content
{
    [Key]
    public int ContentID { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public bool IsLost { get; set; }

    public Content()
    {

    }
    public abstract void Main();

    public abstract void Read();


    







}