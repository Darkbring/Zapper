using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;
using Zapper.Console.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zapper.Console.Models
{
    [Table("Profiles")]
    public class Profile
    {        
        public int Id { get; set; }

        public int UserId { get; set; }

        public SettingFlags Settings { get; set; }
    }
}
