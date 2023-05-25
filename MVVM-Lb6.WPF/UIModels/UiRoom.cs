using System;
using MVVM_lb6.Domain.Models;

namespace MVVM_Lb6.UIModels;

public class UiRoom
{
    public Guid RoomId { get; set; } = Guid.NewGuid();

    public ushort RealNumber { get; set; }

    public byte BedsNumber { get; set; }
    public decimal PricePerDay { get; set; }
    public bool IsAvailable { get; set; }
}