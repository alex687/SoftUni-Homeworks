﻿namespace DistanceCalculatorSoap
{
    using System.Runtime.Serialization;
    using System.ServiceModel;

    [ServiceContract]
    public interface IDistanceCalculator
    {
        [OperationContract]
        double CalculateDistance(Point startPoint, Point endPoint);
    }


    [DataContract]
    public class Point
    {
        [DataMember]
        public int X { get; set; }
        
        [DataMember]
        public int Y { get; set; }
    }
}
