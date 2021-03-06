﻿namespace FurnitureManufacturer.Models
{
    using Interfaces;

    public class AdjustableChair : Chair, IFurniture, IChair, IAdjustableChair
    {
        public AdjustableChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            this.Height = height;
        }
    }
}
