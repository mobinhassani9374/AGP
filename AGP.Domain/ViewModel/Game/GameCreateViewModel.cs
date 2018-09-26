using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AGP.Domain.ViewModel.Game
{
    public class GameCreateViewModel
    {
        [Required(ErrorMessage ="نام بازی نمی تواند فاقد مقدار باشد")]
        public string Name { get; set; }

        [Required(ErrorMessage = "نام نمایشی بازی نمی تواند فاقد مقدار باشد")]
        public string DisplayName { get; set; }
    }
}
