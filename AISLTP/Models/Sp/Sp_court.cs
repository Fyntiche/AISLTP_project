using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AISLTP.Models.Sp
{
    public class Sp_court
    {
        [ScaffoldColumn( false )]
        public int Id { get; set; }

        //[Display( Name = "Код владельца" )]
        [ScaffoldColumn( false )]
        public int Id_parent { get; set; }

       // [Display( Name = "Дата создания" )]
        [ScaffoldColumn( false )]
        public DateTime Dvi { get; set; }

        [ScaffoldColumn( false )]
       // [Display( Name = "Дата редактирования" )]
        public DateTime Dvi_edit { get; set; }

        [ScaffoldColumn( false )]
        //[Display( Name = "Признак удаления" )]
        public byte Is_del { get; set; }

        [Required( ErrorMessage = "Поле должно быть установлено" )]
        [StringLength( 255 , ErrorMessage = "Длина строки должна до 255 символов" )]
        [Display( Name = "Название" )]
        public string Txt { get; set; }

        [Required( ErrorMessage = "Поле должно быть установлено" )]
        [StringLength( 255 , ErrorMessage = "Длина строки должна до 255 символов" )]
        [Display( Name = "Телефон" )]
        public string Tel { get; set; }

        [Required( ErrorMessage = "Поле должно быть установлено" )]
        [StringLength( 255 , ErrorMessage = "Длина строки должна быть 6 символов" )]
        [Display( Name = "Почтовый индекс" )]
        public string Index { get; set; }

        [Display( Name = "Примечание" )]
        [StringLength( 255 , ErrorMessage = "Длина строки должна до 255 символов" )]
        public string Prim { get; set; }
    }
}