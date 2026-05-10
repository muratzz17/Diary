using System.ComponentModel.DataAnnotations;

namespace DiaryApp.Models
{
    public class DiaryEntry
    {
        [Key]       
        public int DiaryEntryId { get; set; }
        //[Required(ErrorMessage = "Başlık Gereklidir")]
        //[StringLength(100, MinimumLength = 3, ErrorMessage = "Başlık en fazla 100 karakter olabilir")]
        public string Title { get; set; }
        [Required(ErrorMessage = "İçerik Gereklidir")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "İçerik en fazla 1000 karakter olabilir")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Tarih Gereklidir")]
        
        public DateTime Created { get; set; }


    }
}
