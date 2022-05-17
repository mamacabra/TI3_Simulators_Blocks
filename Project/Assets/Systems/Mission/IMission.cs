public interface IMission
{
    public string Name { get; }
    public string Description { get; }

    public void Init();
    public void Complete();
    public void Fail();
    public void DrawInfos();
}
