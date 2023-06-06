namespace Hospital_Management.Models
{
    public class Permissions_Insertion
    {
        public int Permission_Id { get; set; }
        public string Permission_Title { get; set; }
        public string Permission_URL { get; set; }
        public int UserRole_Id { get; set; } 
        public bool Status { get; set; }
    }
}
