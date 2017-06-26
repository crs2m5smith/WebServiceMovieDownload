using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceMovieDownload.Models
{
    public class AccountModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string ApiKey { get; set; }

        public DateTime Date { get; set; }
    }
}
