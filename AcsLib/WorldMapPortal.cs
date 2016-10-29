namespace AcsLib
{
    public class WorldMapPortal
    {

        public enum PortalType
        {
            NotUsed,
            Destination,
            WorldMapDestination,
            RoomDestination
        }

        public PortalType TypeOfPortal { get; set; }

        public byte XPosition { get; set; }
        public byte YPosition { get; set; }
        public byte MapDestinationX { get; set; }
        public byte MapDestinationY { get; set; }
        public byte RoomDestinationX { get; set; }
        public byte RoomDestinationY { get; set; }
        public byte DestinationRegion { get; set; }
        public byte DestinationRoom { get; set; }
      
    }
}
