﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CameraBazaar.Models.Constants.ValidationMessages;
using static CameraBazaar.Models.Constants.ValidationRegularExpressions;

namespace CameraBazaar.Models.EntityModels
{
    public class User
    {

        public User()
        {
            this.Cameras = new HashSet<Camera>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [RegularExpression(UsernameRegex, ErrorMessage = UsernameValidationMessage)]
        public string Username { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [RegularExpression(PasswordRegex, ErrorMessage = PasswordValidationMessage)]
        public string Password { get; set; }

        [Required(ErrorMessage = RequiredValidationMessage)]
        [RegularExpression(PhoneRegex, ErrorMessage = PhoneValidationMessage)]
        public string Phone { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public virtual ICollection<Camera> Cameras { get; set; }
    }
}
