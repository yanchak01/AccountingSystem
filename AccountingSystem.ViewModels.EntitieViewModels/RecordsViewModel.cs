using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystem.ViewModels.EntitieViewModels
{
    public class RecordsViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Tittle { get; set; }
        public DateTime DateOfCreating { get; set; }
    }
}
