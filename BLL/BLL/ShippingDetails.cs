using System.ComponentModel.DataAnnotations;

namespace BLL
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "We need your title, so we can treat you as you deserve :)")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Are you sure you selected the right title?")]
        public string Title { get; set; }

        [Required(ErrorMessage = "We need your name, if we have to contact you any time")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Tell us your name, at least 3 characters and a maximum of 100")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "We need your last name, as a legal requirement :(")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Tell us your last name, at least 3 characters and a maximum of 100")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Are you sure you filled correctly the street?")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Tell us your last name, at least 3 characters and a maximum of 250")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Are you sure you filled correctly the house number?")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Tell us your house number, at least 1 characters and a maximum of 10")]
        public string HouseNumber { get; set; }

        [Required(ErrorMessage = "Are you sure you filled correctly the zip code?")]
        [DataType(DataType.PostalCode, ErrorMessage = "The format of the zip code is not correct")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Tell us your zip code, at least 3 characters and a maximum of 20")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Are you sure you filled correctly the city?")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Tell us your city, at least 3 characters and a maximum of 250")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "We need your email, for further information about tracking")]
        [DataType(DataType.EmailAddress, ErrorMessage = "The format of the email is not correct")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Tell us your email, at least 5 characters and a maximum of 200")]
        public string Email { get; set; }
        
        public string ExtraInfo { get; set; }
    }
}