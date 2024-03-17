
using System.Diagnostics.Contracts;

public class StateDB
{
    public enum State //contains all posible directions
    {
        vectorUp,
        vectorRight,
        vectorDown,
        vectorLeft
    }

    public enum MovementState //contains all posible movements states
    {
        idol,
        moving,
        rotaring,
        jumping,
        falling
    }
}
