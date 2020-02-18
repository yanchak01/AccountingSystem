using System;

namespace AccountingSystem.ViewModels.EntitieViewModels
{
    public class RecordsViewModel
    {
        
        public int Id { get; set; }

        
        public int UserId { get; set; }

        
        public string Tittle { get; set; }

        
        public DateTime DateOfCreating { get; set; } = DateTime.Now;
    }
}
