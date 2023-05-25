using System;
using System.Diagnostics.CodeAnalysis;

namespace MVVM_Lb6.UIModels;

public class UiUser
{
    public Guid UserId { get; set; }  = Guid.NewGuid();

    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string PasswordConfirm { get; set; } = "";

    public string IndividualEmployeeNumber { get; set; } = "";
}