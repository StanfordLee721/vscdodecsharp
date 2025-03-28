﻿namespace mvcdebugdemo.Models
{
    [ModelMetadataType(typeof(z_metaTitles))]
    public partial class Titles
    {

    }
}

public class z_metaTitles
{
    [Key]
    public int Id { get; set; }
    [Display(Name = "代號")]
    [Required(ErrorMessage = "登入不可空白!!")]
    public string? TitleNo { get; set; }
    [Display(Name = "名稱")]
    [Required(ErrorMessage = "名稱不可空白!!")]
    public string? TitleName { get; set; }
    [Display(Name = "備註")]
    public string? Remark { get; set; }
}
