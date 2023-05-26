using System;
using MVVM_lb6.Domain.Models;

namespace MVVM_Lb6.UIModels;

public class UiRoom : ICloneable
{
    public Guid RoomId { get; set; } = Guid.NewGuid();

    public ushort RealNumber { get; set; } = 0;

    public byte BedsNumber { get; set; } = 0;
    public decimal PricePerDay { get; set; } = 0;
    public bool IsAvailable { get; set; } = false;
    
    public object Clone()
    {
        return new UiRoom
        {
            RoomId = this.RoomId,
            RealNumber = this.RealNumber,
            BedsNumber = this.BedsNumber,
            PricePerDay = this.PricePerDay,
            IsAvailable = this.IsAvailable,
        };
    }
}