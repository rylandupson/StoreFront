using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StoreFront.DATA//.Metadata
{
    #region Console Metadata
    public class ConsoleMetadata
    {
        //public int ConsoleID { get; set; }

        [Display(Name = "Console")]
        [Required(ErrorMessage = "Console is required")]
        [StringLength(20, ErrorMessage = "*Value must be 20 characters or less")]
        public string ConsoleName { get; set; }
    }

    [MetadataType(typeof(ConsoleMetadata))]
    public partial class Console
    {

    }
    #endregion

    #region Dept Metadata
    public class DeptMetadata
    {
        //public int DeptID { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Department is required")]
        [StringLength(10, ErrorMessage = "*Value must be 10 characters or less")]
        public string DeptName { get; set; }
    }

    [MetadataType(typeof(DeptMetadata))]
    public partial class Dept
    {

    }
    #endregion

    #region Employee Metadata
    public class EmployeeMetadata
    {
        //public int EmpID { get; set; }

        [Display(Name = "First Name")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [StringLength(20, ErrorMessage = "*Value must be 20 characters or less")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [StringLength(20, ErrorMessage = "*Value must be 20 characters or less")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Department ID is required")]
        public int DeptID { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "*Value must be a valid number, 0 or larger")]
        [Display(Name = "Direct Report ID")]
        public Nullable<int> DirectReportID { get; set; }
    }

    [MetadataType(typeof(EmployeeMetadata))]
    public partial class Employee
    {

    }
    #endregion

    #region Game Metadata
    public class GameMetadata
    {
        //public int GameID { get; set; }

        [Display(Name = "Game Title")]
        [Required(ErrorMessage = "Game Title is required")]
        [StringLength(50, ErrorMessage = "*Value must be 50 characters or less")]
        public string GameTitles { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public int GenreID { get; set; }

        [Required(ErrorMessage = "Publisher is required")]
        public int PublisherID { get; set; }

        [Required(ErrorMessage = "Stock Status is required")]
        public int StockID { get; set; }

        [Required(ErrorMessage = "Console is required")]
        public int ConsoleID { get; set; }

        [Range(0, (Double)decimal.MaxValue, ErrorMessage = "Value must be a valid number, 0 or larger")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Price { get; set; }

        [Range(0, (Double)decimal.MaxValue, ErrorMessage = "Value must be a valid number, 0 or larger")]
        [DisplayFormat(DataFormatString = "{0:c}", NullDisplayText = "[-N/A-]")]
        [Display(Name = "Total Sales")]
        public Nullable<decimal> TotalSales { get; set; }

        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Release Date is required")]
        public System.DateTime ReleaseDate { get; set; }

        [StringLength(100, ErrorMessage = "*Value must be 100 characters or less")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        public string Description { get; set; }

        [StringLength(100, ErrorMessage = "*Value must be 100 characters or less")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        public string Image { get; set; }
    }

    [MetadataType(typeof(GameMetadata))]
    public partial class Game
    {

    }
    #endregion

    #region Genre Metadata
    public class GenreMetadata
    {
        //public int GenreID { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Genre is required")]
        [StringLength(10, ErrorMessage = "*Value must be 10 characters or less")]
        public string GenreName { get; set; }
    }

    [MetadataType(typeof(GenreMetadata))]
    public partial class Genre
    {

    }
    #endregion

    #region Publisher Metadata
    public class PublisherMetadata
    {
        //public int PublisherID { get; set; }

        [Display(Name = "Publisher")]
        [Required(ErrorMessage = "Publisher is required")]
        [StringLength(15, ErrorMessage = "*Value must be 15 characters or less")]
        public string PublisherName { get; set; }
    }

    [MetadataType(typeof(PublisherMetadata))]
    public partial class Publisher
    {

    }
    #endregion

    #region Stock Status Metadata
    public class StockStatusMetadata
    {
        //public int StockID { get; set; }

        [Display(Name = "Stock Status")]
        [Required(ErrorMessage = "Stock Status is required")]
        [StringLength(15, ErrorMessage = "*Value must be 15 characters or less")]
        public string IsInStock { get; set; }
    }

    [MetadataType(typeof(StockStatusMetadata))]
    public partial class StockStatus
    {

    }
    #endregion
}
