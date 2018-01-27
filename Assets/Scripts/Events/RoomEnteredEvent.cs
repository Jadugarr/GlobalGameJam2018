namespace Events
{
    public class RoomEnteredEvent : IEvent
    {
        public int RoomNumber;

        public RoomEnteredEvent(int roomNumber)
        {
            RoomNumber = roomNumber;
        }
    }
}