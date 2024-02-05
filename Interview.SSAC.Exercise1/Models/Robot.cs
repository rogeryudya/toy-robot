using Interview.SSAC.Exercise1.Enums;

namespace Interview.SSAC.Exercise1.Models
{
    internal class Robot
    {
        public int? PositionX { get; set; }

        public int? PositionY { get; set; }

        public RobotDirection? Facing { get; set; }

        public bool IsValid { 
            get 
            { 
                return PositionX.HasValue && PositionY.HasValue && Facing.HasValue;
            }
        }
    }
}
