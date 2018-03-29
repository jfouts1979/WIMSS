using System.ComponentModel.DataAnnotations;

//**************************************************************
//*********Establish List for sliderPics ***********************
//**************************************************************

public class SliderPic  // Data Model
{
    public int Id { get; set; }

    [Required, StringLength(256)]
    public string Name { get; set; }

    [Required, StringLength(256)]
    public string ImageURL { get; set; }
}