namespace SaveSystem
{
    public interface ISaver
    {
        public string SaveGame();
        public void LoadGame(string serializedData);

        public string SaverID {  get; set; }
    }
}